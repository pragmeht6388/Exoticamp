using Exoticamp.UI.AuthFilter;
using Exoticamp.UI.Models.ForgotPassword;
using Exoticamp.UI.Models.Login;
using Exoticamp.UI.Models.Registration;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
 


namespace Exoticamp.UI.Controllers
{
    [OutputCache(NoStore = true, Duration = 0)]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class AccountController(IRegistrationRepository _registrationRepository, ILoginRepository _loginRepository, ILocationRepository _locationRepository) : Controller
    { 
                        

        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            ViewBag.Locations = await _locationRepository.GetAllLocations();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration( RegistrationVM registrationVM )
        {
            registrationVM.LocationId = "83dc406a-0018-4752-9798-9c06e078261a";
            var result = await _registrationRepository. CreateRegistration(registrationVM);
            
            if (result.Message != null)
            {
                // ModelState.AddModelError(string.Empty, result.Message);
                TempData["Message"]=  result.Message;
                return View(registrationVM);
            }
            else
            {

                ModelState.AddModelError(string.Empty, "An error occurred while creating the  User.");
            }


            return RedirectToAction("login");

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login( LoginVM request)
        {
            if (!ModelState.IsValid)
            {

                return View(request);
            }
            var response = await _loginRepository.AuthenticateAsync(request);
            if (!response.IsAuthenticated || string.IsNullOrEmpty(response.Token))
            {
                //ModelState.AddModelError(string.Empty, response.Message ?? " Wrong Email and Password, please try again.");
                if(response.Message != null)
                {
                    TempData["Message"] = response.Message;
                }
                else
                {
                    TempData["Message"] = " Wrong Email  please try again.";
                }
                
                return View(request);
            }
            HttpContext.Session.SetString("Token", response.Token);
            HttpContext.Session.SetString("UserRole", response.Role);
            HttpContext.Session.SetString("UserId", response.Id);
            HttpContext.Session.SetString("VendorId", response.Id);
            HttpContext.Session.SetString("UserName", response.Name);
            HttpContext.Session.SetString("LocationId", response.LocationId);





            switch (response.Role)
            {
                case "User":
                    return RedirectToAction("Index", "Home");
                case "Vendor":
                    return RedirectToAction("Dashboard", "Home");
                case "SuperAdmin":
                    return RedirectToAction("AdminPage", "Home");
                default:
                    return RedirectToAction("Index", "Home");  
            }
        }

        [HttpGet]
        [NoCache]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            if (HttpContext.Request.Cookies.ContainsKey(".AspNetCore.Cookies"))
            {
                HttpContext.Response.Cookies.Append(".AspNetCore.Cookies", "", new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(-1)
                });
            }

            return RedirectToAction("Login", "Account");
        }


        //ForgotPassword

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = await _loginRepository.ForgotPasswordAsync(request);

            if (response.ForgotPassword)
            {
                TempData["Message"] = "Forgot password request processed successfully. If an account with the provided email exists, you will receive an email with instructions to reset your password.";
            }
            else
            {
                TempData["Message"] = response.Message ?? "An error occurred while processing your request.";
            }

            return View(request);
        }


    }
}
