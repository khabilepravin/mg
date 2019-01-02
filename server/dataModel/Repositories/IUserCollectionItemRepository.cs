using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface IUserCollectionItemRepository
    {
        Task<UserCollectionItem> AddAsync(UserCollectionItem userCollectionItem);
    }
}
