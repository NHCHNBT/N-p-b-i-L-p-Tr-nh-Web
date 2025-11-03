using Nhan_Xích_Thành_Đồ_án_BE__LTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhan_Xích_Thành_Đồ_án_BE__LTW.Models;
using Nhan_Xích_Thành_Đồ_án_BE__LTW.Models.ViewModel;

namespace Nhan_Xích_Thành_Đồ_án_BE__LTW.Areas.Admin.Controllers
{
    public class CartController : Controller
    {
        private TechPhoneEntities db = new TechPhoneEntities();
        // GET: Admin/Cart
        private CartService GetCartService()
        {
            return new CartService(Session);
        }
        public ActionResult Index()
        {
            var cart = GetCartService().GetCart();
            return View(cart);
        }
        public ActionResult AddToCart(int id , int quantity = 1)
        {
            var product = db.Products.Find(id);
            if(product != null)
            {
                var cartService = GetCartService();
                cartService.GetCart().AddItem(product.ProductID, product.ImageURL, product.ProductName, product.Price, quantity, product.Category.CategoryName);
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int id)
        {
            var cartService = GetCartService();
            cartService.GetCart().RemoveItem(id);
            return RedirectToAction("Index");
        }
        public ActionResult ClearCart()
        {
            GetCartService().ClearCart();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateQuantity(int id, int quantity)
        {
            var cartService = GetCartService();
            cartService.GetCart().UpdateQuantity(id, quantity);
            return RedirectToAction("Index");
        }
    }
}