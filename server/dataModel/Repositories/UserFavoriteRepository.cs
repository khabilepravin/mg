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
                var exitingUserRecord = await (from ur in db.UserFavorite
                                               where ur.UserId == userFavorite.UserId && ur.ParsedTextId == userFavorite.ParsedTextId
                                               select ur).FirstOrDefaultAsync<UserFavorite>();

                if (exitingUserRecord == null)
                {
                    await db.UserFavorite.AddAsync(userFavorite);
                    await db.SaveChangesAsync();

                    return exitingUserRecord;
                }
                else
                {
                    return userFavorite;
                }
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

        public async Task<UserFavorite> GetByParsedTextIdAsync(string parsedTextId)
        {
            using(var db = _dbContextFactory.Create())
            {
                return await (from uf in db.UserFavorite
                                  where uf.ParsedTextId == parsedTextId
                                  select uf).FirstOrDefaultAsync<UserFavorite>();
            }
        }
    }
}
