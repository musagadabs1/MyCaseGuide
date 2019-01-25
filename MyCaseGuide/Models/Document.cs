using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        [Required]
        [Display(Name ="Case to Link")]
        public int MyCaseId { get; set; }
        [Required]
        [Display(Name ="Document Name")]
        public string DocName { get; set; }
        [Required]
        [Display(Name ="Assigned Date")]
        [DataType(DataType.Date)]
        public DateTime AssignedDate { get; set; }
        public string Tags { get; set; }
        [Display(Name ="Doc Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        //[Required]
        [Display(Name ="Document Source")]
        public string DocPath { get; set; }

        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }

        public MyCase MyCase { get; set; }
    }
}