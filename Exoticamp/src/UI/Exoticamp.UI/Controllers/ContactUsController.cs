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
                    ModelState.AddModelError(string.Empty, result.Message);
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "An error occurred while creating the SysPrefCompany.");
                }


                return RedirectToAction("ContactUsAll");

        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = page ?? 1;

            var contactUsEntries = await _contactUsRepository
                .OrderBy(c => c.SubmittedAt)
                .ToPagedListAsync(pageNumber, pageSize);

            return View(contactUsEntries);
        }
    }
}
