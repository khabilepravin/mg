using dataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public interface IUserCollectionManager
    {
        Task<UserCollection> AddAsync(UserCollection userCollection);
        Task<IEnumerable<UserCollection>> SearchAsync(string searchString);
        Task<IEnumerable<UserCollection>> GetUserCollectionsAsync(string userId);
    }
}
