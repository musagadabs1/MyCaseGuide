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
    public class InvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Invoices
        public async Task<ActionResult> Index()
        {
            var user = User.Identity;
            if (HttpContext.User.IsInRole(LegalGuideUtility.ADMINISTRATOR))
            {
                var invoicesAdmin = db.Invoices.Include(i => i.MyCase);
                return View(await invoicesAdmin.ToListAsync());
            }
            var invoices = db.Invoices.Include(i => i.MyCase);
            return View(await invoices.Where(u => u.CreatedBy.Equals(user.Name)).ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = await db.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.MyCaseId = new SelectList(db.MyCases, "MyCaseId", "CaseName");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InvoiceId,MyCaseId,FeeStructure,TotalAmountDue,UnpaidBalance,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity;
                invoice.CreatedBy = user.Name;
                invoice.CreatedDate = DateTime.Today;

                db.Invoices.Add(invoice);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MyCaseId = new SelectList(db.MyCases, "MyCaseId", "CaseName", invoice.MyCaseId);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = await db.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.MyCaseId = new SelectList(db.MyCases, "MyCaseId", "CaseName", invoice.MyCaseId);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InvoiceId,MyCaseId,FeeStructure,TotalAmountDue,UnpaidBalance,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity;
                invoice.ModifiedBy = user.Name;
                invoice.ModifiedDate = DateTime.Today;

                db.Entry(invoice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MyCaseId = new SelectList(db.MyCases, "MyCaseId", "CaseName", invoice.MyCaseId);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = await db.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Invoice invoice = await db.Invoices.FindAsync(id);
            db.Invoices.Remove(invoice);
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
