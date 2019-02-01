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
    public class StaffsController : Controller
    {
        private MyCaseNewEntities db = new MyCaseNewEntities();

        // GET: Staffs
        public async Task<ActionResult> Index()
        {
            return View(await db.Staffs.ToListAsync());
        }

        // GET: Staffs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = await db.Staffs.FindAsync(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StaffId,Surname,OtherNames,Gender,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,Type,DOB,DOE,Status,Address,PostalCode,Town,OfficeNo,MobileNo,EmailAddress,NextOfKin,Relationship,KTelephone,NHISNumber,KRA,Bank,Branch,AccountNumber,SecretCode,Password")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity;
                staff.CreatedBy = user.Name;
                staff.CreatedOn = DateTime.Today;
                db.Staffs.Add(staff);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        // GET: Staffs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = await db.Staffs.FindAsync(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StaffId,Surname,OtherNames,Gender,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn,Type,DOB,DOE,Status,Address,PostalCode,Town,OfficeNo,MobileNo,EmailAddress,NextOfKin,Relationship,KTelephone,NHISNumber,KRA,Bank,Branch,AccountNumber,SecretCode,Password")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity;
                staff.ModifiedBy = user.Name;
                staff.ModifiedOn = DateTime.Today;

                db.Entry(staff).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = await db.Staffs.FindAsync(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Staff staff = await db.Staffs.FindAsync(id);
            db.Staffs.Remove(staff);
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
