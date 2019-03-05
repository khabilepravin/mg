using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface IMediaRepository
    {
        Task<Media> AddAsync(Media media);
        Task<Media> UpdateAsync(Media media);
        Task<Media> GetMedia(string id);
        Task<IEnumerable<Media>> Search(string searchText);
        Task<IEnumerable<ParsedText>> GetMediaText(string mediaId);
    }
}
