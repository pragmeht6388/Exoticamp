using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace Exoticamp.UI.AuthFilter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAuthFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        
        {
            var AdminToken = context.HttpContext.Session.GetString("Token");
            var AdminRole = context.HttpContext.Session.GetString("UserRole");

            
            if (AdminToken == null   || AdminRole != "SuperAdmin")
            {
                 
                context.Result = new RedirectToActionResult("Login", "Account", new { });
            }
        }
    }
    public class VendorAuthFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var VendorToken = context.HttpContext.Session.GetString("Token");
            var VendorRole = context.HttpContext.Session.GetString("UserRole");
 
            if (VendorToken == null || VendorRole != "Vendor")
            {
                 
                context.Result = new RedirectToActionResult("Login", "Account", new { });
            }
        }
    }
    public class UserAuthFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var UserId = context.HttpContext.Session.GetInt32("Token");
            var UserRole = context.HttpContext.Session.GetString("UserRole");

             
            if (UserId == null || UserId == 0)
            {
                 
                context.Result = new RedirectToActionResult("Login", "Account", new { });
            }
        }
    }

    //public class NoCacheAttribute : ActionFilterAttribute
    //{
    //    public override void OnResultExecuting(ResultExecutingContext filterContext)
    //    {
    //        filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
    //        filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
    //        filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //        filterContext.HttpContext.Response.Cache.SetNoStore();

    //        base.OnResultExecuting(filterContext);
    //    }
    //}

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var response = filterContext.HttpContext.Response;

            response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            response.Headers["Pragma"] = "no-cache";
            response.Headers["Expires"] = "-1";
            response.Headers.Remove("ETag");

            base.OnResultExecuting(filterContext);
        }
    }

}
