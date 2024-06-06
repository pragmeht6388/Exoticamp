using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.UserAccountMapping;
using Microsoft.AspNetCore.Http;

namespace Exoticamp.UI.AuthFilter
{
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

}
