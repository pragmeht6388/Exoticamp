using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class SearchController(ISearchRepository _searchRepository) : Controller
    {
         
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
