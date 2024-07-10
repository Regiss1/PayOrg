using Dapper;
using Microsoft.Extensions.Configuration;
using PayOrg.Models;
using PayOrg.Responses;
using PayOrgUser;
using System.Threading.Tasks;

namespace PayOrg.Repository
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

            return loginResponse;
            

        }
    }
}
