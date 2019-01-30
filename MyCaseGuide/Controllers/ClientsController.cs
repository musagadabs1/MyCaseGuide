﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyCaseGuide.Models;
using System.Web.Security;

namespace MyCaseGuide.Controllers
{
    [Authorize(Roles ="Administrator,Attorney,Lawyer")]
    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clients
        public async Task<ActionResult> Index()
        {
            var user = User.Identity;

            if (HttpContext.User.IsInRole(LegalGuideUtility.ADMINISTRATOR))
            {
                return View(await db.Clients.ToListAsync());
            }
            return View(await db.Clients.Where(u => u.CreatedBy.Equals(user.Name)).ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.ContactGroup = new List<SelectListItem>
            {
                new SelectListItem {Text="Client", Value="Client" },
                 new SelectListItem{   Text="Co_Counsel", Value="Co_Counsel" },
                 new SelectListItem{  Text="Expert", Value="Expert" },
                 new SelectListItem{  Text="Judge", Value="Judge" },
                 new SelectListItem{  Text="Unassigned", Value="Unassigned" }

            };
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ClientId,FirstName,MiddleName,LastName,EmailAddress,ContactGroup,PhoneNumber,Address,City,Country,State,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Client client)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity;
                var dateCreated = DateTime.Today;
                client.CreatedBy = user.Name;
                client.CreatedOn = dateCreated;
                db.Clients.Add(client);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ContactGroup = new List<SelectListItem>
            {

                 new SelectListItem {Text="Client", Value="Client" },
                 new SelectListItem{   Text="Co_Counsel", Value="Co_Counsel" },
                 new SelectListItem{  Text="Expert", Value="Expert" },
                 new SelectListItem{  Text="Judge", Value="Judge" },
                 new SelectListItem{  Text="Unassigned", Value="Unassigned" }

            };
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ClientId,FirstName,MiddleName,LastName,EmailAddress,ContactGroup,PhoneNumber,Address,City,Country,State,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Client client)
        {
            if (ModelState.IsValid)
            {
                var user = User.Identity;
                var dateCreated = DateTime.Today;
                client.ModifiedBy = user.Name;
                client.CreatedOn = dateCreated;
                db.Entry(client).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            db.Clients.Remove(client);
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
