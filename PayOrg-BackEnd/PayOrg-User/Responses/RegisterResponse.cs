using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayOrgUser.Responses
{
    public class RegisterResponse : BaseResponse
    {
     public bool EmailAlreadyExists { get; set; }
     public string Email { get; set; }
     public Guid IdUser { get; set; }
    }
}
