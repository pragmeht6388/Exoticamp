using Exoticamp.UI.Models.Registration;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRegistrationRepository _registrationRepository;
        public AccountController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
            
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
            }
            else
            {

                ModelState.AddModelError(string.Empty, "An error occurred while creating the SysPrefCompany.");
            }


            return RedirectToAction("ContactUsAll");

        }
    }
}
