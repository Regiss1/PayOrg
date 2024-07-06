using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PayOrg.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : BaseController
    {
        public PingController(ILogger<LoginController> logger, IConfiguration config) : base(logger, config)
        {
        }
        [HttpGet]
        public string Get()
        {
            return "API em funcionamento";
        }
    }
}
