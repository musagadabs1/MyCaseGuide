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
    public class LoginRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LoginRoles
        public async Task<ActionResult> Index()
        {
            return View(await db.LoginRoles.ToListAsync());
        }

        // GET: LoginRoles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginRole loginRole = await db.LoginRoles.FindAsync(id);
            if (loginRole == null)
            {
                return HttpNotFound();
            }
            return View(loginRole);
        }

        // GET: LoginRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RoleType,RoleDescription,CreatedBy,ModifiedBy,CreatedOn,ModifiedOn")] LoginRole loginRole)
        {
            if (ModelState.IsValid)
            {
                db.LoginRoles.Add(loginRole);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(loginRole);
        }

        // GET: LoginRoles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginRole loginRole = await db.LoginRoles.FindAsync(id);
            if (loginRole == null)
            {
                return HttpNotFound();
            }
            return View(loginRole);
        }

        // POST: LoginRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RoleType,RoleDescription,CreatedBy,ModifiedBy,CreatedOn,ModifiedOn")] LoginRole loginRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginRole).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loginRole);
        }

        // GET: LoginRoles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginRole loginRole = await db.LoginRoles.FindAsync(id);
            if (loginRole == null)
            {
                return HttpNotFound();
            }
            return View(loginRole);
        }

        // POST: LoginRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoginRole loginRole = await db.LoginRoles.FindAsync(id);
            db.LoginRoles.Remove(loginRole);
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
