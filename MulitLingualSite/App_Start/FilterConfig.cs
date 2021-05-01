using MulitLingualSite.Attributes;
using System.Web.Mvc;

namespace MulitLingualSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute());
        }
    }
}
