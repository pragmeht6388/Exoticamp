using Exoticamp.UI.Models.ContactUs;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace Exoticamp.UI.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsController(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }
        public async Task<IActionResult> ContactUsAll()
        {
            var contactUsDetail = await _contactUsRepository.GetAllContacts();
            return View(contactUsDetail);
        }

        [HttpGet]
        public IActionResult ContactUs() {
            return View();
        }

       
        public async Task<IActionResult> ContactUs(ContactUsVM company)
        {

            var result = await _contactUsRepository.AddContact(company);

                if (result.Message != null)
                {
                    TempData["SuccessMessage"] = "Your message has been successfully submitted!";

                    ModelState.AddModelError(string.Empty, result.Message);
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "An error occurred while creating the Contact.");
                }


                return RedirectToAction("ContactUs");

        }

        
    }
}
