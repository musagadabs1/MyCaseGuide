using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public int CaseId { get; set; }
        public int StaffID { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Location { get; set; }
        public string EventName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Case Case { get; set; }
        public Staff Staff { get; set; }
    }
}