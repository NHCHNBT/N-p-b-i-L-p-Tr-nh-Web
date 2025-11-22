using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhan_Xích_Thành_Đồ_án_BE__LTW.Models;

namespace Nhan_Xích_Thành_Đồ_án_BE__LTW.Areas.Admin.Controllers
{
    public class Supplier1Controller : Controller
    {
        private TechPhoneEntities db = new TechPhoneEntities();

        // GET: Admin/Supplier1
        public ActionResult Index()
        {
            return View(db.Suppliers1.ToList());
        }

        // GET: Admin/Supplier1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier1 supplier1 = db.Suppliers1.Find(id);
            if (supplier1 == null)
            {
                return HttpNotFound();
            }
            return View(supplier1);
        }

        // GET: Admin/Supplier1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Supplier1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,SupplierName,Phone,Email,Address")] Supplier1 supplier1)
        {
            if (ModelState.IsValid)
            {
                    db.Suppliers1.Add(supplier1);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }

            return View(supplier1);
        }

        // GET: Admin/Supplier1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier1 supplier1 = db.Suppliers1.Find(id);
            if (supplier1 == null)
            {
                return HttpNotFound();
            }
            return View(supplier1);
        }

        // POST: Admin/Supplier1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,SupplierName,Phone,Email,Address")] Supplier1 supplier1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier1);
        }

        // GET: Admin/Supplier1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier1 supplier1 = db.Suppliers1.Find(id);
            if (supplier1 == null)
            {
                return HttpNotFound();
            }
            return View(supplier1);
        }

        // POST: Admin/Supplier1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier1 supplier1 = db.Suppliers1.Find(id);
            db.Suppliers1.Remove(supplier1);
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
