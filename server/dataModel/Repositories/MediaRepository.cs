using System;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public class MediaRepository : BaseRepository, IMediaRepository
    {
        public MediaRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) {}

        public async Task<Media> AddMedia(Media media, MediaText mediaText)
        {
            using(var db = base._dbContextFactory.Create())
            {
                media.Created = DateTime.UtcNow;
                await db.Media.AddAsync(media);
                

                mediaText.MediaId = media.Id;
                await db.MediaText.AddAsync(mediaText);

                //var parsedText = parser.

                await db.SaveChangesAsync();
                return media;
            }
        }

        public async Task<Media> UpdateMedia(Media media)
        {
            using(var db = base._dbContextFactory.Create())
            {
                media.Modified = DateTime.UtcNow;
                db.Media.Update(media);
                await db.SaveChangesAsync();

                return media;
            }
        }
    }
}
