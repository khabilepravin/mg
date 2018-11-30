using bl;
using Microsoft.AspNetCore.Mvc;
using server.ResponseTypes;

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
        public IActionResult Search([FromRoute]string searchText)
        {
            var searchResults = _search.SearchText(searchText);

            if(searchResults != null)
            {
                return NotFound($"No results found for the \"{searchText}\".");
            }

            return Ok(new ApiOkResponse(searchResults));
        }
    }
}