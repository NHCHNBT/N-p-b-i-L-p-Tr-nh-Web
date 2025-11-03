using Nhan_Xích_Thành_Đồ_án_BE__LTW.Models;
using Nhan_Xích_Thành_Đồ_án_BE__LTW.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhan_Xích_Thành_Đồ_án_BE__LTW.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private TechPhoneEntities db = new TechPhoneEntities();
        // GET: Admin/Order
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Checkout()
        {
            var cart = Session["Cart"] as List<CartItem>;
            if (cart == null || !cart.Any())
            {
                return RedirectToAction("Index", "Home");
            }
            var user = db.Users.SingleOrDefault(u => u.Username == User.Identity.Name);
            if (user == null) 
            {
                return RedirectToAction("Login", "Account");
            }
            var customer = db.Customers.SingleOrDefault(c => c.Username == user.Username);
            if(customer == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var model = new CheckoutVM
            {
                CartItems = cart,
                TotalAmount = cart.Sum(item => item.TotalPrice),
                OrderDate = DateTime.Now,
                ShippingAddress = customer.Address,
                CustomerID = customer.CustomerID,
                Username = customer.Username
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Checkout(CheckoutVM model)
        {
            if (ModelState.IsValid)
            {
                var cart = Session["Cart"] as List<CartItem>;
                if (cart == null || !cart.Any()) { return RedirectToAction("Index", "Home"); }
                var user = db.Users.SingleOrDefault(u => u.Username == User.Identity.Name);
                if (user == null) { return RedirectToAction("Login", "Account"); }
                var customer = db.Customers.SingleOrDefault(c => c.Username == user.Username);
                if (customer == null) { return RedirectToAction("Login", "Account"); }
                if (model.PaymentMethod == "Payal")
                {
                    return RedirectToAction("PaymentWithPayal", "PayPal", model);
                }
                string paymentStatus = "Chưa thanh toán";
                switch (model.PaymentMethod)
                {
                    case "Tiền mặt": paymentStatus = "Thanh toán tiền mặt"; break;
                    case "Paypal": paymentStatus = "Thanh toán Paypal"; break;
                    case "Mua trước trả sau": paymentStatus = "Trả góp"; break;
                    default: paymentStatus = "Chưa thanh toán"; break;
                }
                var order = new Order
                {
                    CustomerID = customer.CustomerID,
                    OrderDate = model.OrderDate,
                    TotalAmount = model.TotalAmount,
                    PaymentStatus = paymentStatus,
                    PaymentMethod = model.PaymentMethod,
                    DeliveryMethod = model.DeliveryMethod,
                    ShippingAddress = model.ShippingAddress,
                    OrderDetails = cart.Select(item => new OrderDetail
                    {
                        ProductID = item.ProductID,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        TotalPrice = item.TotalPrice,
                    }).ToList()
                };
                db.Orders.Add(order);
                db.SaveChanges();
                Session["Cart"] = null;
                return RedirectToAction("OrderSuccess", new { id = order.OrderID });
            }
            return View(model);
        }
    }
}