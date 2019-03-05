using bl;
using dataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using server.ResponseTypes;
using System.IO;
using System.Threading.Tasks;

namespace server.Controllers
{
    public class MediaController : BaseController
    {
        private readonly IMediaManager _mediaManager;

        public MediaController(IMediaManager mediaManager)
        {
            _mediaManager = mediaManager;
        }

        // POST: api/Media
        [HttpPost]
        public async Task<IActionResult> PostMedia([ModelBinder(BinderType = typeof(JsonModelBinder))] Media media)
        {
            var mediaFile = Request.Form.Files != null ? Request.Form.Files[0] : null;
            if (!ModelState.IsValid || mediaFile == null)
            {
                return BadRequest(ModelState);
            }

            var mediaText = new MediaText();

            using (var reader = new StreamReader(mediaFile.OpenReadStream()))
            {
                mediaText.Text = await reader.ReadToEndAsync();
            }

            var newMedia = await _mediaManager.AddMediaParsedAsync(media, mediaText);

            return Ok(new ApiOkResponse(newMedia));
        }

        [HttpGet("{searchText}")]
        public async Task<IActionResult> SearchMedia([FromRoute]string searchText)
        {
            var result = await _mediaManager.Search(searchText);

            return Ok(new ApiOkResponse(result));
        }

        [HttpGet("{mediaId}/text")]
        public async Task<IActionResult> GetMediaText([FromRoute]string mediaId)
        {
            var mediaText = await _mediaManager.GetTextByMedia(mediaId);

            return Ok(new ApiOkResponse(mediaText));
        }
    }
} 