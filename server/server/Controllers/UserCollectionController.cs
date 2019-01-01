using bl;
using dataModel;
using Microsoft.AspNetCore.Mvc;
using server.RequestTypes;
using server.ResponseTypes;
using System.Threading.Tasks;

namespace server.Controllers
{
    public class UserCollectionController : BaseController
    {
        private readonly IUserCollectionManager _userCollectionManager;
        public UserCollectionController(IUserCollectionManager userCollectionManager)
        {
            _userCollectionManager = userCollectionManager;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]UserCollectionRequest userCollectionRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var userCollection = new UserCollection { Name = userCollectionRequest.Name, Description = userCollectionRequest.Description, UserId= userCollectionRequest.UserId };
           var collection = await _userCollectionManager.AddAsync(userCollection, userCollectionRequest.TextIds, userCollectionRequest.CollectionType);

            return Ok(new ApiOkResponse(collection));
        }

    }
}