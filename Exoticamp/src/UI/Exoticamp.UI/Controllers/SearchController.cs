using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchRepository _searchRepository;

        public SearchController(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Search(string text)
        {
            var searchResult = await _searchRepository.SearchContent(text);
            ViewBag.Campsites = searchResult.Data.Campsites;
            ViewBag.Activities = searchResult.Data.Activities;
            ViewBag.Events = searchResult.Data.Events;
          
            return PartialView("_SearchView");
        }
    }
}
