using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        public int ClientId { get; set; }
        public int StaffId { get; set; }
        public string CaseName { get; set; }
        public int CaseNumber { get; set; }
        public DateTime Opened { get; set; }
        public PracticeArea PracticeArea { get; set; }
        public Stage CaseStage { get; set; }
        public string Description { get; set; }
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