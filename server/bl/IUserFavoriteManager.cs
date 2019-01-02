using dataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public interface IUserFavoriteManager
    {
        Task<UserFavorite> AddAsync(UserFavorite userFavorite);
        Task<IEnumerable<ParsedText>> GetAsync(string userId);
    }
}
