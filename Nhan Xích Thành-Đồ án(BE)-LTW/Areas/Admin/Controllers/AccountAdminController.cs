using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhan_Xích_Thành_Đồ_án_BE__LTW.Models;

namespace Nhan_Xích_Thành_Đồ_án_BE__LTW.Areas.Admin.Controllers
{
    public class AccountAdminController : Controller
    {
        private TechPhoneEntities db = new TechPhoneEntities();

        // GET: Admin/AccountAdmin
        public ActionResult Index()
        {
            return View(db.Users1.ToList());
        }

        // GET: Admin/AccountAdmin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User1 user1 = db.Users1.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // GET: Admin/AccountAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AccountAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password,UserRole")] User1 user1)
        {
            if (ModelState.IsValid)
            {
                db.Users1.Add(user1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user1);
        }

        // GET: Admin/AccountAdmin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User1 user1 = db.Users1.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // POST: Admin/AccountAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password,UserRole")] User1 user1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user1);
        }

        // GET: Admin/AccountAdmin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User1 user1 = db.Users1.Find(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(user1);
        }

        // POST: Admin/AccountAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User1 user1 = db.Users1.Find(id);
            db.Users1.Remove(user1);
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
