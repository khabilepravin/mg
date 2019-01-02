using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public class UserFavoriteRepository : BaseRepository, IUserFavoriteRepository
    {
        public UserFavoriteRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<UserFavorite> AddAsync(UserFavorite userFavorite)
        {
            using (var db = _dbContextFactory.Create())
            {
                await db.UserFavorite.AddAsync(userFavorite);
                await db.SaveChangesAsync();

                return userFavorite;
            }
        }

        public async Task<IEnumerable<ParsedText>> GetAsync(string userId)
        {
            using (var db = _dbContextFactory.Create())
            {
                var listUserFavorites = await (from uf in db.UserFavorite
                              where uf.UserId == userId
                              select uf.ParsedTextId).ToListAsync<string>();

                if (listUserFavorites != null && listUserFavorites.Count > 0)
                {
                    return await (from pt in db.ParsedText
                                  where listUserFavorites.Contains(pt.Id)
                                  select pt).ToListAsync<ParsedText>();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
