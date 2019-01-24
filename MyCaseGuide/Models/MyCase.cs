using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class MyCase
    {
        public int MyCaseId { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Client Id is required.")]
        [Display(Name ="Client Id")]
        public int ClientId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Staff Id is required.")]
        [Display(Name = "Staff Id")]
        public int StaffId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Case Name is required.")]
        [Display(Name = "Case Name")]
        public string CaseName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Case Number is required.")]
        [Display(Name = "Case Number")]
        public int CaseNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date Opened is required.")]
        [Display(Name = "Date Opened")]
        [DataType(DataType.Date)]
        public DateTime Opened { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Practice Area is required.")]
        [Display(Name = "Practice Area")]
        public PracticeArea PracticeArea { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Case Stage is required.")]
        [Display(Name = "Case Stage")]
        public Stage CaseStage { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Client Id is required.")]
        [Display(Name = "Case Description")]
        public string Description { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Statute Of Limitation is required.")]
        [Display(Name = "Statute Of Limitation")]
        [DataType(DataType.Date)]
        public DateTime StatuteOfLimitation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Client Client { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
    public enum PracticeArea
    {
        Bankruptcy = 1,
        Business,
        Civil,
        Criminal_Defense,
        Divorce_Separation,
        Employment,
        EstatePlanning,
        Family,
        Tax,
        Landlord_Tenant
    }
    public enum Stage
    {
        Discovery = 1,
        In_Trial,
        On_Hold
    }
}