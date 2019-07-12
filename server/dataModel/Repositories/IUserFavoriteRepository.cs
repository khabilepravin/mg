using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface IUserFavoriteRepository
    {
        Task<UserFavorite> AddAsync(UserFavorite userFavorite);
        Task<IEnumerable<ParsedText>> GetAsync(string userId);
        Task<UserFavorite> GetByParsedTextIdAsync(string parsedTextId);
    }
}
