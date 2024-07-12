using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PayOrgUser.Responses;
using RabbitMQ.Client;
using Newtonsoft.Json;
namespace PayOrgUser.Services;

public interface IQueueServices
{
    public Task<HttpStatusCode> CreateMessage(string response);
    public Task<LoginResponse> ConsumeLoginMessages();
}

class QueueServices : IQueueServices
{

    public Task<HttpStatusCode> CreateMessage(string response)
    {
        string message = JsonConvert.SerializeObject(response);
        try
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            factory.Port = 5672;
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "PayOrg_User",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: string.Empty,
                routingKey: "PayOrg_User",
                basicProperties: null,
                body: body
            );
            return Task.FromResult(HttpStatusCode.Accepted);
        }
        catch (Exception ex)
        {
            return Task.FromResult(HttpStatusCode.BadRequest);
        }

    }

    public Task<LoginResponse> ConsumeLoginMessages()
    {

        return Task.FromResult(new LoginResponse() { AccessId = Guid.NewGuid(), Message = "ok", StatusCode = HttpStatusCode.OK });
    }
}
