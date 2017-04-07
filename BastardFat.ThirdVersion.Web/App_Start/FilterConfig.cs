using System.Web;
using System.Web.Mvc;

namespace BastardFat.ThirdVersion.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
