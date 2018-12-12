using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface IMediaRepository
    {
        Task<Media> AddAsync(Media media);
        Task<Media> UpdateAsync(Media media);
        Task<Media> GetMedia(string id);
    }
}
