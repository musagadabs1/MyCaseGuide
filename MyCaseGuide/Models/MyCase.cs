﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class MyCase:BaseModel
    {
        public int MyCaseId { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Client Name is required.")]
        [Display(Name ="Client Name")]
        public int ClientId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Staff Name is required.")]
        [Display(Name = "Staff Name")]
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
        public string PracticeArea { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Case Stage is required.")]
        [Display(Name = "Case Stage")]
        public string CaseStage { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Client Id is required.")]
        [Display(Name = "Case Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Statute Of Limitation is required.")]
        [Display(Name = "Statute Of Limitation")]
        [DataType(DataType.Date)]
        public DateTime StatuteOfLimitation { get; set; }
        //public Client Client { get; set; }
        //public virtual ICollection<Staff> Staffs { get; set; }
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