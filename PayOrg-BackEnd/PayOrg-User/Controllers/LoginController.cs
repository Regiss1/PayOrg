using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PayOrg.Models;
using PayOrg.Repository;
using PayOrg.Responses;

namespace PayOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private LoginRepository _loginRepository;
        protected string _encryptionKey;
        public LoginController(ILogger<LoginController> logger, IConfiguration config,LoginRepository loginRepository) : base(logger, config)
        {
            _loginRepository = loginRepository;
            _encryptionKey = _configuration.GetValue<string>("Encryption:PwKey");
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login(LoginModel login)
        {
                login.Senha = Common.Cryptography.AES.Encrypt(login.Senha, _encryptionKey);
                LoginResponse loginResponse = await _loginRepository.LoginAsync(login);
            if (loginResponse.Message == "SUCCESS")
            {
                loginResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(loginResponse);
            }
            else
            {
                loginResponse.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                return Unauthorized(loginResponse);
            }


        } 

    }
}
