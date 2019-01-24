using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CaseId { get; set; }
        public float FeeStructure { get; set; }
        public decimal TotalAmountDue { get; set; }
        public decimal UnpaidBalance { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public MyCase Case { get; set; }
    }
}