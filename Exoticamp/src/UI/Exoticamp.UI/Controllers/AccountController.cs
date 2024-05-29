﻿using Exoticamp.UI.Models.Login;
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
                ModelState.AddModelError(string.Empty, result.Message);
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
            HttpContext.Session.SetString("UserRole", response.Role);

             
            {
                case "User":
                    return RedirectToAction("Index", "Home");
                case "Vendor":
                    return RedirectToAction("Registration", "Account");
                case "SuperAdmin":
                    return RedirectToAction("Dashboard", "SuperAdmin");
                default:
                    return RedirectToAction("Index", "Home");  
            }
    }
}