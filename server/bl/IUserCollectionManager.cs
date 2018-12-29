using dataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public interface IUserCollectionManager
    {
        Task<UserCollection> AddAsync(UserCollection userCollection, IEnumerable<string> userCollectionItemIds, string collectionType);
        Task<IEnumerable<UserCollection>> SearchAsync(string searchString);
        Task<IEnumerable<UserCollection>> GetUserCollectionsAsync(string userId);
    }
}
