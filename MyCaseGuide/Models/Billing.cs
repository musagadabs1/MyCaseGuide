using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class Billing
    {
        public int BillingId { get; set; }
        public int ClientId { get; set; }
        public BillingMethod BillingMethod { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Client Client { get; set; }
    }
    public enum BillingMethod
    {
        Hourly = 1,
        Contingency,
        FlatFee,
        FlatFeeAndHourly,
        ProBono
    }
}