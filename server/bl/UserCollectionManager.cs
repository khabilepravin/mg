using dataModel;
using dataModel.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public class UserCollectionManager : IUserCollectionManager
    {
        private readonly IUserCollectionRepository _userCollectionRepository;
        private readonly IUserCollectionItemRepository _userCollectionItemRepository;
        public UserCollectionManager(IUserCollectionRepository userCollectionRepository, IUserCollectionItemRepository userCollectionItemRepository)
        {
            _userCollectionRepository = userCollectionRepository;
            _userCollectionItemRepository = userCollectionItemRepository;
        }

        public async Task<UserCollection> AddAsync(UserCollection userCollection, IEnumerable<string> userCollectionItemIds, string collectionType)
        {
            var collection = await _userCollectionRepository.AddAsync(userCollection);

            foreach(var item in userCollectionItemIds)
            {
                var collectionItem = new UserCollectionItem();
                collectionItem.CollectionId = collection.Id;
                collectionItem.EntityId = item;
                collectionItem.EntityType = collectionType;
                await _userCollectionItemRepository.AddAsync(collectionItem);
            }

            return collection;
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
