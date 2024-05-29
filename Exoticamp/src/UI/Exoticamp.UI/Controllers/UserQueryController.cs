using Exoticamp.UI.Models.UserQuery;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class UserQueryController : Controller
    {
        private readonly IUserQueryRepository _userQueryRepository;
        public UserQueryController(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _userQueryRepository.GetAllUserQueries();
            return View(list);
        }

        public async Task<IActionResult> Respond(string Id)
        {
            var userQuery = await _userQueryRepository.GetUserQueryById(Id);
            return PartialView("_PartialRespondModal", userQuery.data);
        }

        [HttpPost]
        public async Task<IActionResult> Respond(UserQueyVM model)
        {
            var userQuery = await _userQueryRepository.RespondToUserQuery(model);
            if(userQuery.data != null)
            {
                return RedirectToAction("Index");
            }
            return PartialView("_PartialRespondModal", userQuery);
        }
    }
}
