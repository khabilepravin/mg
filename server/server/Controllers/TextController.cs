using bl;
using Microsoft.AspNetCore.Mvc;
using System;
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

            return Ok(result);
        }

        [HttpGet("mediatext/{mediaId}")]
        public async Task<IActionResult> GetPopularTextByMediaId([FromRoute]string mediaId)
        {
            var result = await _textManager.GetPopularTextForMedia(mediaId);

            return Ok(result);
        }

        [HttpGet("{textId}")]
        public async Task<IActionResult> GetTextSurroundingText([FromRoute]string textId, string proximity)
        {
            var result = await _textManager.GetSurroundingText(textId, (string.IsNullOrWhiteSpace(proximity) ? 6 : Convert.ToInt32(proximity)));

            return Ok(result);
        }
    }
}