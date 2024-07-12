using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayOrgUser.Models
{
    public class BillTypeModel
    {
        public Guid IdBillType { get; set; }
        public Guid? IdUser { get; set; }
        public string BillTypeName { get; set; }
    }
}
