using bl;
using Microsoft.AspNetCore.Mvc;
using server.RequestTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Controllers
{
    public class TagController : BaseController
    {
        private readonly ITagManager _tagManager;
        private readonly ITextTagManager _textTagManager;
        public TagController(ITagManager tagManager, ITextTagManager textTagManager)
        {
            _tagManager = tagManager;
            _textTagManager = textTagManager;
        }

        [HttpPost("media/{mediaId}")]
        public async Task<IActionResult> AddTagToMedia([FromBody]IEnumerable<string> tagIds, [FromRoute]string mediaId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recordsAffected = await _tagManager.AddTagsForMedia(tagIds, mediaId);

            return Ok(recordsAffected);
        }

        [HttpPost]
        public async Task<IActionResult> AddTag([FromBody]AddTagRequest addTagRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tagRecord = await _tagManager.AddTag(addTagRequest.TagText);

            return Ok(tagRecord);
        }

        [HttpPost("text/{textId}")]
        public async Task<IActionResult> AddTextTag([FromBody]IEnumerable<string> tagIds, [FromRoute]string textId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var affectedRows = await _textTagManager.AddTextTag(tagIds, textId);

            return Ok(affectedRows);
        }
    }
}