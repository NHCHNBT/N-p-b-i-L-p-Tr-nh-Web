using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhan_Xích_Thành_Đồ_án_BE__LTW.Models;
using Nhan_Xích_Thành_Đồ_án_BE__LTW.Models.ViewModel;
using PagedList;

namespace Nhan_Xích_Thành_Đồ_án_BE__LTW.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private TechPhoneEntities db = new TechPhoneEntities();

        // GET: Admin/Products
        public ActionResult Index(string searchTerm,decimal? minPrice,decimal? maxPrice,string sortOrder,int? page)
        {
            var model = new ProductSearchVM();
            var products = db.Products.AsQueryable();
            if(!string.IsNullOrEmpty(searchTerm) )
            {
                products = products.Where(p =>
                p.ProductName.Contains(searchTerm) ||
                p.Description.Contains(searchTerm) ||
                p.Category.CategoryName.Contains(searchTerm));
            }
            if(minPrice.HasValue)
            {
                products = products.Where(p=>p.Price >= minPrice.Value);
            }
            if(maxPrice.HasValue)
            {
                products = products.Where(p=>p.Price <= maxPrice.Value);
            }
            switch(sortOrder)
            {
                case "name_asc": products = products.OrderBy(p => p.ProductName);
                    break;
                case "name_desc": products = products.OrderByDescending(p => p.ProductName); 
                    break;
                case "price_asc": products = products.OrderBy(p=>p.Price); 
                    break;
                case "price_desc": products = products.OrderByDescending(p => p.Price);
                    break;
                default:
                    products = products.OrderBy(p=>p.ProductName);
                    break;
            }
            model.SortOrder = sortOrder;

            int pageNumber = page ?? 1;
            int pageSize = 2;

            model.Products = products.ToPagedList(pageNumber,pageSize);
            //var products = db.Products.Include(p => p.Brand).Include(p => p.Category);
            return View(model);
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", product.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,CategoryID,BrandID,ProductName,Description,Price,StockQuantity,ImageURL,WarrantyMonths")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", product.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }
        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,CategoryID,BrandID,ProductName,Description,Price,StockQuantity,ImageURL,WarrantyMonths")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", product.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
