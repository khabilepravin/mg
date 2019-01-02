using dataModel;
using dataModel.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public class UserFavoriteManager : IUserFavoriteManager
    {
        private readonly IUserFavoriteRepository _userFavoriteRepository;
        public UserFavoriteManager(IUserFavoriteRepository userFavoriteRepository)
        {
            _userFavoriteRepository = userFavoriteRepository;
        }

        public async Task<UserFavorite> AddAsync(UserFavorite userFavorite)
        {
            return await _userFavoriteRepository.AddAsync(userFavorite);
        }

        public async Task<IEnumerable<ParsedText>> GetAsync(string userId)
        {
            return await _userFavoriteRepository.GetAsync(userId);
        }
    }
}
