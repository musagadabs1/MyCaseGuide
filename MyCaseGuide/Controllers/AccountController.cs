using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MyCaseGuide.Models;

namespace MyCaseGuide.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;
        //private ApplicationDbContext _context =new ApplicationDbContext();
        private readonly MyCaseNewEntities db = new MyCaseNewEntities();



        public AccountController()
        {
        }

        //public AccountController(/*ApplicationUserManager userManager, ApplicationSignInManager signInManager*/ )
        //{
        //    //UserManager = userManager;
        //    //SignInManager = signInManager;
        //    //_context = context;
        //}

        //public ApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        //    }
        //    private set 
        //    { 
        //        _signInManager = value; 
        //    }
        //}

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public  ActionResult Login(FormCollection model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string username = model["txtUsername"];
            string password = model["txtPassword"];

            var loginInfo = GetLogins(username, password);
            if (loginInfo != null && loginInfo.Count() > 0)
            {
                var loginDetails = loginInfo.FirstOrDefault();
                this.SignInUser(loginDetails.Username, false);
                return RedirectToLocal(returnUrl);
            }
            return View(model);
        }

        private void SignInUser(string username, bool isPersistent)
        {
            var claims = new List<Claim>();
            try
            {
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdentities = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var context = Request.GetOwinContext();
                var authenticationManager = context.Authentication;
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdentities);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private List<LoginVM> GetLogins(string username, string password)
        {
            List<LoginVM> loginVMs = new List<LoginVM>();
            //password = LegalGuideUtility.Encrypt(password);
            try
            {
                MyCaseNewEntities db = new MyCaseNewEntities();

                var getUsers = db.LoginUsers.Where(u => u.Username == username && u.Password == password).Select(u => new LoginVM
                {
                    Username = u.Username,
                    Password = u.Password,
                    RoleId = (int)u.RoleId
                });

                foreach (var item in getUsers)
                {
                    loginVMs.Add(new LoginVM
                    {
                        Username = item.Username,
                        Password = item.Password,
                        RoleId=item.RoleId
                        
                    });
                }

                return loginVMs;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private bool IsLogin(string username, string password)
        {
            try
            {
                MyCaseNewEntities db = new MyCaseNewEntities();
                var success = false;
                var getUser = (from lo in db.LoginUsers
                               where lo.Username == username && lo.Password == password
                               select new
                               {
                                   lo.Username,
                                   lo.Password
                               }).FirstOrDefault();

                if (getUser != null)
                {
                    success = true;
                }
                return success;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {

            ViewBag.RoleNames = new SelectList(db.UserRoles.Where(u => u.RoleType != "Admin").ToList(), "Id", "RoleType");
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public  ActionResult Register(LoginUser model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedBy = model.Username;
                model.CreatedOn = DateTime.Today.Date;
                //model.Password = LegalGuideUtility.Encrypt(model.Password);
                db.LoginUsers.Add(model);
                db.SaveChanges();

               return RedirectToAction("Login", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            var context = Request.GetOwinContext();
            var authenticationManager = context.Authentication;
            authenticationManager.SignOut();
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    //db = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers

       private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
           
        #endregion
    }
}