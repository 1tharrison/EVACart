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
    public class StaffController : Controller
    {
        private EVACartEntities db = new EVACartEntities();
        // GET: Staff

        public ActionResult Index()
        {
            var eVACstaff = db.Staffs.Include(t => t.DepartmentID);
            return View(eVACstaff.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff eVACstaff = db.Staffs.Find(id);
            if (eVACstaff == null)
            {
                return HttpNotFound();
            }
            return View(eVACstaff);
        }
        [Authorize]
        // GET: Employees/Create
        public ActionResult Create()
        {
            var RoleManager = HttpContext.GetOwinContext()
           .Get<ApplicationRoleManager>();
            ViewBag.RoleId = new SelectList(RoleManager.Roles.ToList(), "Name", "Name");
            ViewBag.DepartmentID = new SelectList(db.Staffs, "DepartmentID", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from over-posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Address1,Address2,City,State,Zip,Phone1,Phone2,Title,Email,D.O.B,DepartmentID,StartDate,Notes,IsActive,")] Staff eVACstaff, HttpPostedFileBase EmpImage, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                //create an identity userId and Role and add the user to the role
                //create a user manager
                var userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //create an app user object
                var newUser = new ApplicationUser()
                {
                    UserName = eVACstaff.Email,
                    Email = eVACstaff.Email
                };
                //create user account with default password
                userManager.Create(newUser, "Evac@1change");
                //actually sets the default password

                //Could send Email to the address with the default password and ask them to change it.
                //do not use the GMail relay, use your CentriqHosting information
                //check the identity.config for email stuff.


                //assign the user to the role selected from the check box
                if (selectedRoles != null)
                {
                    userManager.AddToRoles(newUser.Id, selectedRoles);
                }
                //assign back to the TSTEmployee object the new user ID
                eVACstaff.UserID = newUser.Id;//GUID
                //Employee Image

                //Default to no image available
                string fileName = "NoImage.png";
                //If the file upLoad has a file (no null)
                if (EmpImage != null)
                {
                    //File Exists
                    //create whitelist of extensions
                    //string[] extensions = new string[] { ".jpeg", ".png", ".gif" };
                    //get the file name from the upload
                    fileName = EmpImage.FileName;
                    //use that name to get the extension
                    string ext = fileName.Substring(fileName.LastIndexOf('.'));
                    //check the white list
                    //if (!extensions.Contains(ext)) 
                    //{

                    //return View(tSTEmployee);
                    //}
                    //rename the file using a guid
                    fileName = Guid.NewGuid() + ext;
                    //save to the web server
                    EmpImage.SaveAs(Server.MapPath("~Content/StaffImg/" + fileName));
                }
                eVACstaff.Image = fileName;
                db.Staffs.Add(eVACstaff);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //get roles from identity
            //added using statements to the top
            var RoleManager = HttpContext.GetOwinContext()
                .Get<ApplicationRoleManager>();
            ViewBag.RoleId = new SelectList(RoleManager.Roles.ToList(), "Name", "Name");

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", eVACstaff.DepartmentID);
            return View(eVACstaff);
        }
        [Authorize]
        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff eVACstaff = db.Staffs.Find(id);
            if (eVACstaff == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "Name", eVACstaff.DepartmentID);
            return View(eVACstaff);

        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistID,FirstName,LastName,Address1,Address2,City,State,Zip,Phone1,Phone2,Title,Email,D.O.B,DepartmentID,StartDate,UserID,Image,Notes,IsActive,DateOfSeparation")]
            EvacArtists eVACstaff, HttpPostedFileBase EmpImage)
        {
            string fileName = "tonyNo.png";
            if (ModelState.IsValid)
            {

                //Employee Image
                if (EmpImage != null)
                {
                    fileName = EmpImage.FileName;
                    string ext = fileName.Substring(fileName.LastIndexOf('.'));
                    fileName = Guid.NewGuid() + ext;
                    EmpImage.SaveAs(Server.MapPath("~Content/Images/ArtistsImg/" + fileName));
                    eVACstaff.Image = fileName;
                }

                db.Entry(eVACstaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DeptName", eVACstaff.DepartmentID);
            return View(eVACstaff);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff eVACstaff = db.Staffs.Find(id);
            if (eVACstaff == null)
            {
                return HttpNotFound();
            }
            return View(eVACstaff);
        }
        [Authorize]
        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff eVACstaff = db.Staffs.Find(id);
            //Comment out hard delete 
            //  db.TSTEmployees.Remove(tSTEmployee);
            //change to soft delete
            eVACstaff.IsActive = !eVACstaff.IsActive;
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
