using Exoticamp.UI.Models.Chatbot;
using Exoticamp.UI.Models.UserQuery;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class ChatbotController : Controller
    {
        private readonly IChatbotRepository _chatbotRepository;
        public ChatbotController(IChatbotRepository chatbotRepository)
        {
            _chatbotRepository = chatbotRepository;
        }
        [HttpGet]
        public IActionResult ChatbotPartial()
        {
            //var concerns = _context.Concerns.Where(c => c.ParentId == null).ToList();
            return PartialView("_PartialChatbotView", new List<ChatbotVM>());
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
