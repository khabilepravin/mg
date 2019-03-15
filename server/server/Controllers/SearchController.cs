using bl;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    public class SearchController : BaseController
    {
        private ISearch _search;
        public SearchController(ISearch search)
        {
            _search = search;
        }

        [HttpGet("{searchText}")]
        public IActionResult Search([FromRoute]string searchText, string titleId)
        {
            var searchResults = _search.SearchText(searchText, null, titleId);

            if(searchResults == null)
            {
                return NotFound($"No results found for the \"{searchText}\".");
            }

            return Ok(searchResults);
        }
    }
}