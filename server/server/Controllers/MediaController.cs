using bl;
using dataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
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

        // GET: api/Media
        [HttpGet]
        public IEnumerable<Media> GetMedia()
        {
            return null;// _context.Media;
        }

        // POST: api/Media
        [HttpPost]
        public async Task<IActionResult> PostMedia([ModelBinder(BinderType = typeof(JsonModelBinder))] Media media,
                IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mediaText = new MediaText();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                mediaText.Text = await reader.ReadToEndAsync();
            }

            var newMedia = await _mediaManager.AddMediaParsedAsync(media, mediaText);

            return Ok(newMedia);
        }
    }
}