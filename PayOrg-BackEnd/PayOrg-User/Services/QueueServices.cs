using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PayOrg.Responses;
using RabbitMQ.Client;

namespace PayOrgUser;

interface IQueueServices
{
    public Task<HttpStatusCode> CreateMessage(string message);
    public Task<LoginResponse> ConsumeLoginMessages(Guid messageGuid);
}

class QueueServices : IQueueServices
{

    public Task<HttpStatusCode> CreateMessage(string message)
    {
        Guid messageGuid = Guid.NewGuid();
        
        try {
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
            routingKey: "user",
            basicProperties: null,
            body: body
        );
        return Task.FromResult(HttpStatusCode.Accepted);
        }
        catch (Exception ex) {
            return Task.FromResult(HttpStatusCode.BadRequest);
        }

    }

    public Task<LoginResponse> ConsumeLoginMessages(Guid messageGuid) {

    return Task.FromResult(new LoginResponse(){ AccessId= Guid.NewGuid(), Message = "ok", StatusCode = HttpStatusCode.OK});
    }
}
