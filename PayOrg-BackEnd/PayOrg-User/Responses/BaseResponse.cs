﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PayOrgUser.Responses
{
    public class BaseResponse
    {
            public HttpStatusCode StatusCode { get; set; }
            public string Message { get; set; }
    }
}
