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
    public class EventsController : Controller
    {
        private EVACartEntities db = new EVACartEntities();
        // GET: Events

        public ActionResult Index()
        {
            //var eVACevents = db.Events.Include(t => t.DepartmentID).Include(t => t.ArtistID).Include(t => t.Department).Include(t => t.EvacArtists);
         
            //return View(eVACevents.ToList());
            return View();
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           Event eVACevents = db.Events.Find(id);
            if (eVACevents == null)
            {
                return HttpNotFound();
            }
            return View(eVACevents);
        }
        [Authorize]
        // GET: Events/Create
        public ActionResult Create()
        {
            var RoleManager = HttpContext.GetOwinContext()
           .Get<ApplicationRoleManager>();
            ViewBag.RoleId = new SelectList(RoleManager.Roles.ToList(), "Name", "Name");
            ViewBag.DepartmentID = new SelectList(db.Events, "DepartmentID", "Name");
            ViewBag.GalleryID = new SelectList(db.Galleries, "GalleryID", "Name");
            ViewBag.ArtistID = new SelectList(db.EvacArtists, "ArtistID", "FirstName");
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "FirstName");
            return View();
        }

        // POST: Events/Create
        // To protect from over-posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventName,Address1,Adderss2,City,State,Zip,Phone,DepartmentID,Description,GalleryID,ArtistID,StaffID")] Event eVACevents, HttpPostedFileBase EventImage)
        {
            string fileName = "NoImage";
            if (ModelState.IsValid)
            {

                if (EventImage != null)
                {
                    fileName = EventImage.FileName;
                    string ext = fileName.Substring(fileName.LastIndexOf('.'));
                    fileName = Guid.NewGuid() + ext;
                    EventImage.SaveAs(Server.MapPath("~Content/EventImg/" + fileName));
                    eVACevents.Image = fileName;
                }

                db.Entry(eVACevents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", eVACevents.DepartmentID);
            ViewBag.GalleryID = new SelectList(db.Galleries, "GalleryID", "Name", eVACevents.GalleryID);
            ViewBag.ArtistID = new SelectList(db.EvacArtists, "ArtistID", "FirstName", eVACevents.ArtistID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "FirstName", eVACevents.StaffID);
            return View(eVACevents);
        }   
        // GET: Events/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event eVACevents = db.Events.Find(id);
            if (eVACevents == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", eVACevents.DepartmentID);
            ViewBag.GalleryID = new SelectList(db.Galleries, "GalleryID", "Name", eVACevents.GalleryID);
            ViewBag.ArtistID = new SelectList(db.EvacArtists, "ArtistID", "FirstName", eVACevents.ArtistID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "FirstName", eVACevents.StaffID);
            return View(eVACevents);

        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventName,Address1,Address2,City,State,Zip,Phone,DepartmentID,Description,GalleryID,StaffID,")] Event eVACevents, HttpPostedFileBase EventImage, string[] selectedRoles)
        {
            string fileName = "NoImage.png";
            if (ModelState.IsValid)
            {

                //Event Image
                if (EventImage != null)
                {
                    fileName = EventImage.FileName;
                    string ext = fileName.Substring(fileName.LastIndexOf('.'));
                    fileName = Guid.NewGuid() + ext;
                    EventImage.SaveAs(Server.MapPath("~Content/EventImg/" + fileName));
                    eVACevents.Image = fileName;
                }

                db.Entry(eVACevents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", eVACevents.DepartmentID);
            ViewBag.GalleryID = new SelectList(db.Galleries, "GalleryID", "Name", eVACevents.GalleryID);
            ViewBag.ArtistID = new SelectList(db.EvacArtists, "ArtistID", "FirstName", eVACevents.ArtistID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "FirstName", eVACevents.StaffID);
            return View(eVACevents);
           
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event eVACevents = db.Events.Find(id);
            if (eVACevents == null)
            {
                return HttpNotFound();
            }
            return View(eVACevents);
        }
        [Authorize]
        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event eVACevents = db.Events.Find(id);
     
           db.Events.Remove(eVACevents);
          
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
