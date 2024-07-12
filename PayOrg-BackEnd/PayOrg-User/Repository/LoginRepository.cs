using Dapper;
using Microsoft.Extensions.Configuration;
using PayOrgUser.Models;
using PayOrgUser.Responses;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayOrgUser.Services;

namespace PayOrgUser.Repository
{
    public class LoginRepository : BaseRepository
    {
        private string _sql = "EXEC USR_LOGIN @email, @senha, @Ip";
        private QueueServices _qServices = new QueueServices();
        public LoginRepository(IConfiguration config) : base(config)
        {

        }
        public async Task<LoginResponse> LoginAsync(LoginModel login)
        {
            var loginResponse = await UseSqlConnection(async conn =>
            {

                return  await conn.QueryFirstAsync<LoginResponse>(_sql, new
                {
                    login.Email,
                    login.Senha,
                    login.Ip
                });
                

            });

            string message =  JsonConvert.SerializeObject(loginResponse);
            _qServices.CreateMessage(message);
            return loginResponse;
            

        }
    }
}
