using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCaseGuide.Models
{
    public class LoginRole:BaseModel
    {
        public int Id { get; set; }
        public string RoleType { get; set; }
        public string RoleDescription { get; set; }
    }
}