﻿using Exoticamp.UI.AuthFilter;
using Exoticamp.UI.Models.ContactUs;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace Exoticamp.UI.Controllers
{

    public class ContactUsController(IContactUsRepository _contactUsRepository) : Controller
    {
      
        [AdminAuthFilter]
        [NoCache]
        public async Task<IActionResult> ContactUsAll()
        {
            var contactUsDetail = await _contactUsRepository.GetAllContacts();
            return View(contactUsDetail);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ContactUs() {
            return View();
        }

        [AllowAnonymous]
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
