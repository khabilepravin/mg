using bl;
using dataModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return Ok(_search.SearchText(searchText));
        }
    }
}