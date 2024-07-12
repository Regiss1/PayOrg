using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayOrgUser.Responses
{
    public class LoginResponse : BaseResponse
    {
        public Guid AccessId { get; set; }
    }
}
