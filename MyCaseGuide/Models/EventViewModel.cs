using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class EventViewModel
    {
        public string EventName { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
    }
}