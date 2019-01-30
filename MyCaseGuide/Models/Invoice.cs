using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class Invoice:BaseModel
    {
        public int InvoiceId { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Case Id Required.")]
        [Display(Name ="Case Id")]
        public int MyCaseId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fee Structure Required.")]
        [Display(Name = "Fee Structure")]
        public float FeeStructure { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Total Amount Due Required.")]
        [Display(Name = "Total Amount Due")]
        public decimal TotalAmountDue { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unpaid Balance Required.")]
        [Display(Name = "Unpaid Balance")]
        public decimal UnpaidBalance { get; set; }
        public MyCase MyCase { get; set; }
    }
}