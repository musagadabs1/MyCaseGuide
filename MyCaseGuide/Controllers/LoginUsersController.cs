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
    public class LoginUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LoginUsers
        public async Task<ActionResult> Index()
        {
            return View(await db.LoginUsers.ToListAsync());
        }

        // GET: LoginUsers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginUser loginUser = await db.LoginUsers.FindAsync(id);
            if (loginUser == null)
            {
                return HttpNotFound();
            }
            return View(loginUser);
        }

        // GET: LoginUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Username,Password,RoleId,CreatedBy,ModifiedBy,CreatedOn,ModifiedOn")] LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                db.LoginUsers.Add(loginUser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(loginUser);
        }

        // GET: LoginUsers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginUser loginUser = await db.LoginUsers.FindAsync(id);
            if (loginUser == null)
            {
                return HttpNotFound();
            }
            return View(loginUser);
        }

        // POST: LoginUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Username,Password,RoleId,CreatedBy,ModifiedBy,CreatedOn,ModifiedOn")] LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loginUser);
        }

        // GET: LoginUsers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginUser loginUser = await db.LoginUsers.FindAsync(id);
            if (loginUser == null)
            {
                return HttpNotFound();
            }
            return View(loginUser);
        }

        // POST: LoginUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoginUser loginUser = await db.LoginUsers.FindAsync(id);
            db.LoginUsers.Remove(loginUser);
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
