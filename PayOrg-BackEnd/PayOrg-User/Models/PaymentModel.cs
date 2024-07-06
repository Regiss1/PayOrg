using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayOrg.Models
{
    public class PaymentModel
    {
        public Guid IdUser { get; set; }
        public Guid IdPayment { get; set; }
        public decimal ValuePayed { get; set; }
        public decimal? Discounts{ get; set; }
        public decimal Fines { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool Automatic { get; set; }
        public Guid PlannedPaymentId { get; set; }
    }
}
