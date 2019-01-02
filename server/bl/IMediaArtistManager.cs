using dataModel;
using System.Threading.Tasks;

namespace bl
{
    public interface IMediaArtistManager
    {
        Task<MediaArtist> AddAsync(MediaArtist mediaArtist);
    }
}
