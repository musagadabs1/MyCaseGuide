using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyCaseGuide.Models;

namespace MyCaseGuide.Controllers
{
    [Authorize(Roles = "Administrator,Attorney,Lawyer")]
    public class MyCasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyCases
        public async Task<ActionResult> Index()
        {
            var user = User.Identity;

            if (HttpContext.User.IsInRole(LegalGuideUtility.ADMINISTRATOR))
            {
                var myCasesAdmin = db.MyCases.Include(m => m.Client);
                return View(await myCasesAdmin.ToListAsync());
                //return View(await db.Clients.ToListAsync());
            }
            //return View(await db.Clients.Where(u => u.CreatedBy.Equals(user.Name)).ToListAsync());
            var myCases = db.MyCases.Include(m => m.Client);
            return View(await myCases.Where(u => u.CreatedBy.Equals(user.Name)).ToListAsync());
        }

        // GET: MyCases/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCase myCase = await db.MyCases.FindAsync(id);
            if (myCase == null)
            {
                return HttpNotFound();
            }
            return View(myCase);
        }

        // GET: MyCases/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName");
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FirstName " );
            return View();
        }

        // POST: MyCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MyCaseId,ClientId,StaffId,CaseName,CaseNumber,Opened,PracticeArea,CaseStage,Description,StatuteOfLimitation,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MyCase myCase)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity;
                myCase.CreatedBy = user.Name;
                myCase.CreatedDate = DateTime.Today;

                db.MyCases.Add(myCase);
                await db.SaveChangesAsync();

                return RedirectToAction("Create","Invoices");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName " , myCase.ClientId);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FirstName " ,myCase.StaffId);
            return View(myCase);
        }

        // GET: MyCases/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCase myCase = await db.MyCases.FindAsync(id);
            if (myCase == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", myCase.ClientId);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FirstName " ,myCase.StaffId);
            return View(myCase);
        }

        // POST: MyCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MyCaseId,ClientId,StaffId,CaseName,CaseNumber,Opened,PracticeArea,CaseStage,Description,StatuteOfLimitation,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] MyCase myCase)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity;
                myCase.ModifiedBy = user.Name;
                myCase.ModifiedDate = DateTime.Today;

                db.Entry(myCase).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", myCase.ClientId);
            ViewBag.StaffId = new SelectList(db.Staffs, "StaffId", "FirstName " , myCase.StaffId);
            return View(myCase);
        }

        // GET: MyCases/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCase myCase = await db.MyCases.FindAsync(id);
            if (myCase == null)
            {
                return HttpNotFound();
            }
            return View(myCase);
        }

        // POST: MyCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MyCase myCase = await db.MyCases.FindAsync(id);
            db.MyCases.Remove(myCase);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
