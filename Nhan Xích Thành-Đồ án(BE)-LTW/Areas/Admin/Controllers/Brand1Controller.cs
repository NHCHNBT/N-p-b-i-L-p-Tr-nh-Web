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
    public class Brand1Controller : Controller
    {
        private TechPhoneEntities db = new TechPhoneEntities();

        // GET: Admin/Brand1
        public ActionResult Index()
        {
            return View(db.Brands1.ToList());
        }

        // GET: Admin/Brand1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand1 brand1 = db.Brands1.Find(id);
            if (brand1 == null)
            {
                return HttpNotFound();
            }
            return View(brand1);
        }

        // GET: Admin/Brand1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brand1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrandID,BrandName,Country")] Brand1 brand1)
        {
            if (ModelState.IsValid)
            {
                db.Brands1.Add(brand1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brand1);
        }

        // GET: Admin/Brand1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand1 brand1 = db.Brands1.Find(id);
            if (brand1 == null)
            {
                return HttpNotFound();
            }
            return View(brand1);
        }

        // POST: Admin/Brand1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrandID,BrandName,Country")] Brand1 brand1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand1);
        }

        // GET: Admin/Brand1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand1 brand1 = db.Brands1.Find(id);
            if (brand1 == null)
            {
                return HttpNotFound();
            }
            return View(brand1);
        }

        // POST: Admin/Brand1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand1 brand1 = db.Brands1.Find(id);
            db.Brands1.Remove(brand1);
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
