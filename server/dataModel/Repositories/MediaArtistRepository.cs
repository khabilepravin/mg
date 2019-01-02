using System;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public class MediaArtistRepository : BaseRepository, IMediaArtistRepository
    {
        public MediaArtistRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<MediaArtist> AddAsync(MediaArtist mediaArtist)
        {
            using (var db = base._dbContextFactory.Create())
            {
                mediaArtist.Created = DateTime.UtcNow;
                await db.MediaArtist.AddAsync(mediaArtist);
                await db.SaveChangesAsync();
                return mediaArtist;
            }
        }
    }
}
