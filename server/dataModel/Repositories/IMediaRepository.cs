using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface IMediaRepository
    {
        Task<Media> AddMedia(Media media, MediaText mediaText);
        Task<Media> UpdateMedia(Media media);
    }
}
