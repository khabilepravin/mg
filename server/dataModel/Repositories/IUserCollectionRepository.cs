using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface IUserCollectionRepository
    {
        Task<UserCollection> AddAsync(UserCollection userCollection);
        Task<IEnumerable<UserCollection>> SearchAsync(string searchString);
        Task<IEnumerable<UserCollection>> GetUserCollectionsAsync(string userId);
    }
}
