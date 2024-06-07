using Exoticamp.UI.Models.Login;
using Exoticamp.UI.Models.Registration;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly ILoginRepository _loginRepository;
        public AccountController(IRegistrationRepository registrationRepository, ILoginRepository loginRepository)
        {
            _registrationRepository = registrationRepository;
            _loginRepository = loginRepository;
        }
                        

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration( RegistrationVM registrationVM )
        {

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
            HttpContext.Session.SetString("UserName", response.UserName);




            switch (response.Role)
            {
                case "User":
                    return RedirectToAction("Index", "Home");
                case "Vendor":
                    return RedirectToAction("Dashboard", "Home");
                case "SuperAdmin":
                    return RedirectToAction("GetAllUsers", "Admin");
                default:
                    return RedirectToAction("Index", "Home");  
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}
