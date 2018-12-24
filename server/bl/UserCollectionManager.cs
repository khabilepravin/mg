using dataModel;
using dataModel.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public class UserCollectionManager : IUserCollectionManager
    {
        private readonly IUserCollectionRepository _userCollectionRepository;
        public UserCollectionManager(IUserCollectionRepository userCollectionRepository)
        {
            _userCollectionRepository = userCollectionRepository;
        }

        public async Task<UserCollection> AddAsync(UserCollection userCollection)
        {
            return await _userCollectionRepository.AddAsync(userCollection);
        }

        public async Task<IEnumerable<UserCollection>> GetUserCollectionsAsync(string userId)
        {
            return await _userCollectionRepository.GetUserCollectionsAsync(userId);
        }

        public async Task<IEnumerable<UserCollection>> SearchAsync(string searchString)
        {
            return await _userCollectionRepository.SearchAsync(searchString);
        }
    }
}
