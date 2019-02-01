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
using System.IO;

namespace MyCaseGuide.Controllers
{
    //[Authorize(Roles ="Administrator,Attorney,Lawyer")]
    public class DocumentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Documents
        public async Task<ActionResult> Index()
        {
            var user = User.Identity;
            if (HttpContext.User.IsInRole(LegalGuideUtility.ADMINISTRATOR))
            {
                var adminDocuments = db.Documents.Include(d => d.MyCase);
                return View(await adminDocuments.ToListAsync());
            }
            var documents = db.Documents.Include(d => d.MyCase);
            return View(await documents.Where(u => u.CreatedBy.Equals(user.Name)).ToListAsync());
        }

        // GET: Documents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = await db.Documents.FindAsync(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Create
        public ActionResult Create()
        {
            ViewBag.MyCaseId = new SelectList(db.MyCases, "MyCaseId", "CaseName");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DocumentId,MyCaseId,DocName,AssignedDate,Tags,Description,DocPath,CreatedBy,DateCreated,ModifiedBy,DateModified")] Document document, HttpPostedFileBase file)
        {
            string fileName = string.Empty;
            string filePath = string.Empty;
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0 && file != null)
                {
                    filePath = file.FileName;
                    fileName = Path.GetFileName(file.FileName);
                }
                var folderPath = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/Docs";
                var docPath = Path.Combine(folderPath, filePath);

                var user = User.Identity;
                document.CreatedBy = user.Name;
                document.CreatedOn = DateTime.Today;
                document.DocPath = fileName;
                

                db.Documents.Add(document);
                await db.SaveChangesAsync();
                return RedirectToAction("Create","CaseEvents");
            }

            ViewBag.MyCaseId = new SelectList(db.MyCases, "MyCaseId", "CaseName", document.MyCaseId);
            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = await db.Documents.FindAsync(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.MyCaseId = new SelectList(db.MyCases, "MyCaseId", "CaseName", document.MyCaseId);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DocumentId,MyCaseId,DocName,AssignedDate,Tags,Description,DocPath,CreatedBy,DateCreated,ModifiedBy,DateModified")] Document document,HttpPostedFileBase file)
        {
            string filePath = string.Empty;
            string fileName = string.Empty;
            if (ModelState.IsValid)
            {
                if (file.ContentLength>0 && file !=null)
                {
                    filePath = file.FileName;
                    fileName = Path.GetFileName(file.FileName);
                }
                var folderPath = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/Docs";
                var docPath = Path.Combine(folderPath, filePath);

                var user = User.Identity;
                document.ModifiedOn = DateTime.Today;
                document.ModifiedBy = user.Name;
                document.DocPath = fileName;
                

                db.Entry(document).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Create", "CaseEvents");
            }
            ViewBag.MyCaseId = new SelectList(db.MyCases, "MyCaseId", "CaseName", document.MyCaseId);
            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = await db.Documents.FindAsync(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Document document = await db.Documents.FindAsync(id);
            db.Documents.Remove(document);
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
