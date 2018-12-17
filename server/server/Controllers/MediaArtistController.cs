using bl;
using dataModel;
using Microsoft.AspNetCore.Mvc;
using server.ResponseTypes;
using System.Threading.Tasks;

namespace server.Controllers
{
    public class MediaArtistController : BaseController
    {
        private readonly IMediaArtistManager _mediaArtistManager;
        public MediaArtistController(IMediaArtistManager mediaArtistManager)
        {
            _mediaArtistManager = mediaArtistManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(MediaArtist mediaArtist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMediaArtist = await _mediaArtistManager.AddAsync(mediaArtist);

            return Ok(new ApiOkResponse(newMediaArtist));
        }

    }
}