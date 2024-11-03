using System.Web;
using System.Web.Mvc;

namespace K22CNTT3_LeTranKhanhDuy_2210900020
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
