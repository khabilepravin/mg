using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface IMediaArtistRepository
    {
        Task<MediaArtist> AddAsync(MediaArtist mediaArtist);
    }
}
