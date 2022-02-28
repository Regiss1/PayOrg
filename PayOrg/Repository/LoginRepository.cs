using Dapper;
using Microsoft.Extensions.Configuration;
using PayOrg.Models;
using PayOrg.Responses;
using System.Threading.Tasks;

namespace PayOrg.Repository
{
    public class LoginRepository : BaseRepository
    {
        private string _sql = "EXEC USR_LOGIN @email, @senha, @Ip";
        public LoginRepository(IConfiguration config) : base(config)
        {

        }
        public async Task<LoginResponse> LoginAsync(LoginModel login)
        {
            return await UseSqlConnection(async conn =>
            {

                return await conn.QueryFirstAsync<LoginResponse>(_sql, new
                {
                    login.Email,
                    login.Senha,
                    login.Ip
                });
            });
        }
    }
}
