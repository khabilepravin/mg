using dataModel;
using dataModel.Repositories;
using System.Threading.Tasks;

namespace bl
{
    public class MediaArtistManager : IMediaArtistManager
    {
        private readonly IMediaArtistRepository _mediaArtistRepository;
        public MediaArtistManager(IMediaArtistRepository mediaArtistRepository)
        {
            _mediaArtistRepository = mediaArtistRepository;
        }

        public async Task<MediaArtist> AddAsync(MediaArtist mediaArtist)
        {
            return await _mediaArtistRepository.AddAsync(mediaArtist);
        }
    }
}
