using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayOrgUser.Models
{
    public class BillModel
    {
        public Guid IdBill { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdCompany { get; set; }
        public int  DueDay { get; set; }
        public bool SendEmail { get; set; }
        public Guid IdBillType { get; set; }
        public DateTime? FirsPayment { get; set; }
        public DateTime? NextPayment { get; set; }
        public bool SendWPPMessage { get; set; }
        public string Periodicity { get; set; }
        public bool AutomaticDebit { get; set; }
        public bool Reajusts { get; set; }
        public decimal PlannedValue { get; set; }
    }
}
