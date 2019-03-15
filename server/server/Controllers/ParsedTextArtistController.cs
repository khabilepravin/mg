using bl;
using dataModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace server.Controllers
{
    public class ParsedTextArtistController : BaseController
    {
        private readonly IParsedTextArtistManager _parsedTextArtistManager;
        public ParsedTextArtistController(IParsedTextArtistManager parsedTextArtistManager)
        {
            _parsedTextArtistManager = parsedTextArtistManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ParsedTextArtist parsedTextArtist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedEntity = await _parsedTextArtistManager.AddAsync(parsedTextArtist);

            return Ok(addedEntity);
        }
    }
}