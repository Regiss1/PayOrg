using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PayOrgUser;

namespace PayOrg.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : BaseController
    {

        private QueueServices queueServices = new QueueServices();
        public PingController(ILogger<LoginController> logger, IConfiguration config) : base(logger, config)
        {
        }
        [HttpGet]
        public string Get()
        {
            
            Random r = new Random();
            queueServices.CreateMessage(r.Next(0, 1000).ToString());
            return "API em funcionamento com docker";

        }
    }
}
