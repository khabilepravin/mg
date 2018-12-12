using bl;
using Microsoft.AspNetCore.Mvc;
using server.ResponseTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Controllers
{
    public class TextController : BaseController
    {
        private readonly ITextManager _textManager;
        public TextController(ITextManager textManager)
        {
            _textManager = textManager;
        }

        [HttpPost("grouptext")]
        public async Task<IActionResult> GroupText([FromBody]IEnumerable<string> textIds)
        {
            if(textIds == null || textIds.Count() == 0)
            {
                return BadRequest("No collection provided for grouping");
            }

            var result = await _textManager.GroupText(textIds);

            return Ok(new ApiOkResponse(result));
        }
    }
}