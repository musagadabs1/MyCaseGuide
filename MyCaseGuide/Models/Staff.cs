using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public int BillingRate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Case> Cases { get; set; }
    }
}