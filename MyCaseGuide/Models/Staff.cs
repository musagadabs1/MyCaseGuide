using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Type is Required.")]
        [Display(Name = "User Type")]
        public string UserType { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Billing Rate is Required.")]
        [Display(Name = "Billing Rate")]
        public int BillingRate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<MyCase> MyCases { get; set; }
    }
}