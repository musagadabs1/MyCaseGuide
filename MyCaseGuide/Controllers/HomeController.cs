using MyCaseGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCaseGuide.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEventData()
        {
            var user = User.Identity;
            var result = new JsonResult();
            List<CaseEvent> events = new List<CaseEvent>();
            try
            {
                //var getEvents=_context.Eve

                return result;
            }
            catch (Exception ex)
            {

                Console.Write(ex);
            }
            return result;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}