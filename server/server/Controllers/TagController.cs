using bl;
using Microsoft.AspNetCore.Mvc;
using server.RequestTypes;
using server.ResponseTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Controllers
{
    public class TagController : BaseController
    {
        private readonly ITagManager _tagManager;
        public TagController(ITagManager tagManager)
        {
            _tagManager = tagManager;
        }

        [HttpPost("{mediaId}")]
        public async Task<IActionResult> AddTagToMedia([FromBody]IEnumerable<string> tagIds, [FromRoute]string mediaId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recordsAffected = await _tagManager.AddTagsForMedia(tagIds, mediaId);

            return Ok(new ApiOkResponse(recordsAffected));
        }

        [HttpPost]
        public async Task<IActionResult> AddTag([FromBody]AddTagRequest addTagRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tagRecord = await _tagManager.AddTag(addTagRequest.TagText);

            return Ok(new ApiOkResponse(tagRecord));
        }
    }
}