using bl;
using dataModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace server.Controllers
{
    public class UserFavoriteController : BaseController
    {
        private readonly IUserFavoriteManager _userFavoriteManager;
        public UserFavoriteController(IUserFavoriteManager userFavoriteManager)
        {
            _userFavoriteManager = userFavoriteManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]UserFavorite userFavorite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedEntity = await _userFavoriteManager.AddAsync(userFavorite);

            return Ok(addedEntity);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get([FromRoute]string userId)
        {
            var userFavorites = await _userFavoriteManager.GetAsync(userId);

            return Ok(userFavorites);
        }
    }
}