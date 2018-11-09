using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface IMediaRepository
    {
        Task<Media> AddMedia(Media media);
        Task<Media> UpdateMedia(Media media);
    }
}
