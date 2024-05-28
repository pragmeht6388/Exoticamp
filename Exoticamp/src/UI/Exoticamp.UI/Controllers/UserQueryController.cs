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
    }
}
