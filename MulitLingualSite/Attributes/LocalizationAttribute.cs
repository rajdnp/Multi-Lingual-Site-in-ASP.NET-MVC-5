using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MulitLingualSite.Attributes
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        public LocalizationAttribute()
        {

        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isLangKeyExist = filterContext.RouteData.Values.ContainsKey("lang");

            if (isLangKeyExist)
            {
                string lang = filterContext.RouteData.Values["lang"].ToString().Trim().ToLower();
                if (!string.IsNullOrEmpty(lang)) SetCulture(lang);
            }
            else
            {
                string lang = HttpContext.Current.Request.Headers["Accept-Language"].Split(',')[0].ToString();
                if (!string.IsNullOrEmpty(lang)) SetCulture(lang);
            }
        }

        private static void SetCulture(string lang)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
            }
            catch (System.Exception e)
            {
                throw new NotSupportedException(string.Format("ERROR: Invalid language code '{0}'.", lang));
            }
        }
    }
}
