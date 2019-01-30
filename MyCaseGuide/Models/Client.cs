using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class Client:BaseModel
    {
        public int ClientId { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="First Name is Required.")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is Required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Address is Required.")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Client Group.")]
        [Display(Name = "Client Group")]
        public string ContactGroup { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile Number is Required.")]
        [Display(Name = "Mobile Number")]
        public string PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Client Address is Required.")]
        [Display(Name = "Client Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

    }

}