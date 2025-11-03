using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using Nhan_Xích_Thành_Đồ_án_BE__LTW.Models;
using Nhan_Xích_Thành_Đồ_án_BE__LTW.Models.ViewModel;
using PagedList;

namespace Nhan_Xích_Thành_Đồ_án_BE__LTW.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private TechPhoneEntities db = new TechPhoneEntities();

        // GET: Admin/Home
        public ActionResult Index(string searchTerm,int? page)
        {
            var model = new HomeProductVM();
            var products = db.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                model.SearchTerm = searchTerm;
                products = products.Where(p => p.ProductName.Contains(searchTerm) || p.Description.Contains(searchTerm) || p.Category.CategoryName.Contains(searchTerm));

            }
            int pageNumber = page ?? 1;
            int pageSize = 6;

            model.FeaturedProducts = products.OrderByDescending(p => p.OrderDetails.Count()).Take(10).ToList();
            model.NewProducts = products.OrderBy(p => p.OrderDetails.Count()).Take(20).ToPagedList(pageNumber, pageSize);
            return View(model);
        }
        public ActionResult ProductDetails(int? id, int? quantity,int? page)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product pro = db.Products.Find(id);
            if(pro == null)
            {
                return HttpNotFound();
            }
            var products = db.Products.Where(p=>p.CategoryID == pro.CategoryID && p.ProductID != pro.ProductID ).AsQueryable();
            ProductDetailsVM model = new ProductDetailsVM();

            int pageNumber = page ?? 1;
            int pageSize = model.PageSize;
            model.product = pro;
            model.RelatedProducts = products.OrderBy(p =>p.ProductID).Take(8).ToPagedList(pageNumber,pageSize);
            model.TopProducts = products.OrderByDescending(p=>p.OrderDetails.Count()).Take(8).ToPagedList(pageNumber, pageSize);
            if(quantity.HasValue)
            {
                model.quantity  = quantity.Value;
            }
            return View(model);
        }
    }
}