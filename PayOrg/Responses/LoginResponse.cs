using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayOrg.Responses
{
    public class LoginResponse : BaseResponse
    {
        public Guid AccessId { get; set; }
    }
}
