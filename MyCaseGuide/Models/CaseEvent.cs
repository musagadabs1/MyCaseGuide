using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class CaseEvent
    {
        public int CaseEventId { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Case Id is Required.")]
        [Display(Name ="Case Id")]
        public int MyCaseId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Staff Id is Required.")]
        [Display(Name = "Staff Id")]
        public int StaffID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date And Time is Required.")]
        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        [Display(Name = "End")]
        [DataType(DataType.Date)]
        public DateTime End { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Case Location is Required.")]
        [Display(Name = "Case Location")]
        public string Location { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Name is Required.")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Address is Required.")]
        [Display(Name = "Event Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Event Description is Required.")]
        [Display(Name = "Event Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public MyCase MyCase { get; set; }
        public Staff Staff { get; set; }
    }
}