using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="First Name is Required.")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required.")]
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
        public Group ContactGroup { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile Number is Required.")]
        [Display(Name = "Mobile Number")]
        public string PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Client Address is Required.")]
        [Display(Name = "Client Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required.")]
        //[Display(Name = "First Name")]
        public string City { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required.")]
        //[Display(Name = "First Name")]
        public string Country { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required.")]
        //[Display(Name = "First Name")]
        public string State { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

}
public enum Group
{
    Client = 1,
    Co_Counsel,
    Expert,
    Judge,
    Unassigned
}