using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PayOrg.Controllers
{
    public class BaseController : Controller
    {
        protected ILogger _logger;
        protected IConfiguration _configuration;
        protected BaseController(ILogger<BaseController> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;

        }
    }
}
