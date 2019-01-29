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
            //var result = new JsonResult();
            List<EventViewModel> events = new List<EventViewModel>();
            try
            {
                var getEvents = _context.CaseEvents.ToList();

                foreach (var item in getEvents)
                {
                    events.Add(new EventViewModel
                    {
                        EventName=item.EventName,
                        Location=item.Location,
                        Start=item.Start,
                        End=item.End,
                        Description=item.Description
                    });
                }


                return Json(events,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return result;
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