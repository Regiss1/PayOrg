using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayOrg.Models
{
    public class CompanyModel
    {
        public Guid? IdUser { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Contact2 { get; set; }
        public string Url { get; set; }
        public string App { get; set; }
        public string Country { get; set; }
    }
}
