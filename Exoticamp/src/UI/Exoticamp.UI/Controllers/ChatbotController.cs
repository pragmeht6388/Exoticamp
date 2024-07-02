using Exoticamp.UI.Models.Chatbot;
using Exoticamp.UI.Models.UserQuery;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class ChatbotController(IChatbotRepository _chatbotRepository) : Controller
    {
        
        [HttpGet]
        public async Task<IActionResult> ChatbotPartial(string concernId)
        {
            var concerns = await _chatbotRepository.GetChatbotResponseById(concernId);
            if (concernId is null)
            {
                return PartialView("_PartialChatbotView", concerns.data);
            }

            return Json(new { response = concerns.data });


        }

        [HttpPost]
        public async Task<IActionResult> SubmitQuery(string email, string query)
        {
            var model = new UserQueyVM()
            {
                Email = email,
                Query = query
            };
            var result = await _chatbotRepository.CreateUserQuery(model);
            // Optionally, you can return some JSON or empty content if no specific response is needed
            return Json(new { success = result.Success, message = "Your query has been submitted successfully! Wait for a response from our team!" });
        }

    }
}
