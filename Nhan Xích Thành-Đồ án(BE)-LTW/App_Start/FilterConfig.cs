using System.Web;
using System.Web.Mvc;

namespace Nhan_Xích_Thành_Đồ_án_BE__LTW
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
