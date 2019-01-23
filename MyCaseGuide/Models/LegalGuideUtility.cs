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
        //public static bool IsAdminUser()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var user = User.Identity;
        //        ApplicationDbContext context = new ApplicationDbContext();
        //        var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

        //        var getRole = userManager.GetRoles(user.GetUserId());
        //        if (getRole[0].ToString() == "Administrator")
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return false;
        //    //throw new NotImplementedException();
        //}
    }
}