using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Permissions;
using PagedList.Mvc;
using PagedList;

namespace Nhan_Xích_Thành_Đồ_án_BE__LTW.Models.ViewModel
{
    public class ProductDetailsVM
    {
        public Product products { get; set; }
        public int quantity { get; set; }
        public decimal estimatedValue { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;
        public List<Product> RelatedProduct { get; set; }
        public PagedList.IPagedList<Product> TopProducts { get; set; }
        public IPagedList<Product> RelatedProducts { get; internal set; }
        public Product product { get; internal set; }
    }
}