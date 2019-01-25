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
    public class CaseEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CaseEvents
        public async Task<ActionResult> Index()
        {
            var caseEvents = db.CaseEvents.Include(c => c.MyCase).Include(c => c.Staff);
            return View(await caseEvents.ToListAsync());
        }

        // GET: CaseEvents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseEvent caseEvent = await db.CaseEvents.FindAsync(id);
            if (caseEvent == null)
            {
                return HttpNotFound();
            }
            return View(caseEvent);
        }

        // GET: CaseEvents/Create
        public ActionResult Create()
        {
            ViewBag.MyCaseId = new SelectList(db.MyCases, "MyCaseId", "CaseName");
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffId", "FirstName");
            return View();
        }

        // POST: CaseEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CaseEventId,MyCaseId,StaffID,DateAndTime,Location,EventName,Address,Description,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] CaseEvent caseEvent)
        {
            if (ModelState.IsValid)
            {
                db.CaseEvents.Add(caseEvent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MyCaseId = new SelectList(db.MyCases, "MyCaseId", "CaseName", caseEvent.MyCaseId);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffId", "FirstName", caseEvent.StaffID);
            return View(caseEvent);
        }

        // GET: CaseEvents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseEvent caseEvent = await db.CaseEvents.FindAsync(id);
            if (caseEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.MyCaseId = new SelectList(db.MyCases, "MyCaseId", "CaseName", caseEvent.MyCaseId);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffId", "FirstName", caseEvent.StaffID);
            return View(caseEvent);
        }

        // POST: CaseEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CaseEventId,MyCaseId,StaffID,DateAndTime,Location,EventName,Address,Description,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] CaseEvent caseEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caseEvent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MyCaseId = new SelectList(db.MyCases, "MyCaseId", "CaseName", caseEvent.MyCaseId);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffId", "FirstName", caseEvent.StaffID);
            return View(caseEvent);
        }

        // GET: CaseEvents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseEvent caseEvent = await db.CaseEvents.FindAsync(id);
            if (caseEvent == null)
            {
                return HttpNotFound();
            }
            return View(caseEvent);
        }

        // POST: CaseEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CaseEvent caseEvent = await db.CaseEvents.FindAsync(id);
            db.CaseEvents.Remove(caseEvent);
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
