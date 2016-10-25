using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EVACart.Data.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EVACart3.Controllers
{
    public class GalleryController : Controller

    {
        private EVACartEntities db = new EVACartEntities();
        // GET: Gallery

        public ActionResult Index()
        {
            var eVACgallery = db.Galleries.Include(t => t.DepartmentID);
            return View(eVACgallery.ToList());
        }

        // GET: Gallery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery eVACgallery = db.Galleries.Find(id);
            if (eVACgallery == null)
            {
                return HttpNotFound();
            }
            return View(eVACgallery);
        }
        [Authorize]
        // GET: Gallery/Create
        public ActionResult Create()
        {
            var RoleManager = HttpContext.GetOwinContext()
           .Get<ApplicationRoleManager>();
            ViewBag.RoleId = new SelectList(RoleManager.Roles.ToList(), "Name", "Name");
            ViewBag.DepartmentID = new SelectList(db.Galleries, "DepartmentID", "Name");
            return View();
        }

        // POST: Gallery/Create
        // To protect from over-posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GalleryID,Name,ContactName,Address1,Address2,City,State,Zip,Phone,Email,ArtistID,EventID,DepartmentID,")] Gallery eVACgallery)
        {
           if (ModelState.IsValid)
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
        [Authorize]
        // GET: Gallery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery eVACgallery = db.Galleries.Find(id);
            if (eVACgallery == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", eVACgallery.DepartmentID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eVACgallery.EventID);
            ViewBag.ArtistID = new SelectList(db.EvacArtists, "ArtistID", "FirstName", eVACgallery.ArtistID);
            return View(eVACgallery);

        }

        // POST: Gallery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GalleryID,Name,ContactName,Address1,Address2,City,State,Zip,Phone,Email,ArtistID,EventID,DepartmentID,")] Gallery eVACgallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eVACgallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", eVACgallery.DepartmentID);
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eVACgallery.EventID);
            ViewBag.ArtistID = new SelectList(db.EvacArtists, "ArtistID", "FirstName", eVACgallery.ArtistID);
            return View(eVACgallery);
        }

        // GET: Gallery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery eVACgallery = db.Galleries.Find(id);
            if (eVACgallery == null)
            {
                return HttpNotFound();
            }
            return View(eVACgallery);
        }

        [Authorize]
        // POST: Gallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery eVACgallery = db.Galleries.Find(id);
       
           db.Galleries.Remove(eVACgallery);
          
        
            db.SaveChanges();
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
