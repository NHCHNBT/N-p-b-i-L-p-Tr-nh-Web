using System.Web.Mvc;

namespace Nhan_Xích_Thành_Đồ_án_BE__LTW.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(name: "Admin_default",
                             url: "Admin/{controller}/{action}/{id}",
                             defaults: new { action = "Index", id = UrlParameter.Optional },
                             new[] { "Nhan_Xích_Thành_Đồ_án_BE__LTW.Areas.Admin.Controllers" });
        }
    }
}