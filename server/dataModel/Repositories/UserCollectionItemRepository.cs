using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public class UserCollectionItemRepository : BaseRepository, IUserCollectionItemRepository
    {
        public UserCollectionItemRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }
        public async Task<UserCollectionItem> AddAsync(UserCollectionItem userCollectionItem)
        {
            using (var db = _dbContextFactory.Create())
            {
                await db.UserCollectionItem.AddAsync(userCollectionItem);
                await db.SaveChangesAsync();
                return userCollectionItem;
            }
        }
    }
}
