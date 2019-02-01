//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCaseGuide.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class LoginUser
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="User Name")]
        public string Username { get; set; }
        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="User Role")]
        [Required]
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        [Display(Name ="Is Active ?")]
        public bool IsActive { get; set; }
    
        public virtual UserRole UserRole { get; set; }
    }
}
