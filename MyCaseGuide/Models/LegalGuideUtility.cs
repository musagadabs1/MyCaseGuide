using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyCaseGuide.Models
{
    public static class LegalGuideUtility
    {
        public const string ADMINISTRATOR = "Administrator";
        public const string ATTORNEY = "Attorney";
        public const string LAWYER = "Lawyer";
        public const string User = "User";

        public static List<string> Roles = new List<string> { "Administrator", "Attorney", "Lawyer", "User" };
    }
}