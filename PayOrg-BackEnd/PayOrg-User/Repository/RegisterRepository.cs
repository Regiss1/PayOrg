using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using static PayOrgUser.Controllers.RegisterController;
using PayOrgUser.Models;
using PayOrgUser.Responses;

namespace PayOrgUser.Repository
{
    public class RegisterRepository : BaseRepository
    {
        private string _sql = "EXEC USR_REGISTER @email, @senha";
        public RegisterRepository(IConfiguration config) : base(config)
        {

        }
        public async Task<RegisterResponse> CreateAsync(RegisterModel register)
        {
            return await UseSqlConnection(async conn =>
            {
                
                return await conn.QueryFirstAsync<RegisterResponse>(_sql, new
                {
                    register.Email,
                    register.Senha
                });
            });
        }
    }
}
