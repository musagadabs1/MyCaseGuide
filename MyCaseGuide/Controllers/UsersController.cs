using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyCaseGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCaseGuide.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;
                ViewBag.DisplayMenu = "No";
                if (IsAdminUser())
                {
                    ViewBag.DisplayMenu = "Yes";
                }
                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged In.";
            }
            return View();
        }

        private bool IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var getRole = userManager.GetRoles(user.GetUserId());
                if (getRole[0].ToString()=="Administrator")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
            //throw new NotImplementedException();
        }
    }
}