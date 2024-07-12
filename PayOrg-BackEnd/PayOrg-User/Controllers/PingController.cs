using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Globalization;
using PayOrgUser.Services;

namespace PayOrg.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingController : BaseController
    {

        private QueueServices _queueServices;
        public PingController(ILogger<LoginController> logger, IConfiguration config, IQueueServices queueServices) : base(logger, config)
        {
            _queueServices = new QueueServices();
        }
        [HttpGet]
        public string Get()
        {
            
            //Random r = new Random();
            //queueServices.CreateMessage(r.Next(0, 1000).ToString());
            return $"API em funcionamento com docker {DateTime.Now:dd/MM/yyyy hh:mm:ss}";

        }
    }
}
