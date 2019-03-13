using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dataModel.Repositories
{
    public class MediaRepository : BaseRepository, IMediaRepository
    {   
        public MediaRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) {}

        public async Task<Media> AddAsync(Media media)
        {
            using(var db = base._dbContextFactory.Create())
            {
                media.Created = DateTime.UtcNow;
                await db.Media.AddAsync(media);
                await db.SaveChangesAsync();
                return media;
            }
        }

        public async Task<Media> UpdateAsync(Media media)
        {
            using(var db = base._dbContextFactory.Create())
            {
                media.Modified = DateTime.UtcNow;
                db.Media.Update(media);
                await db.SaveChangesAsync();

                return media;
            }
        }

        public async Task<Media> GetMedia(string id)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await db.Media.FindAsync(id);
            }
        }

        public async Task<IEnumerable<Media>> Search(string searchText)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from m in db.Media
                              where m.Name.Contains(searchText)
                              select m).ToListAsync<Media>();
            }
        }

        public async Task<IEnumerable<ParsedText>> GetMediaText(string mediaId)
        {
            using(var db = base._dbContextFactory.Create())
            {
                var mediaTextId = await (from m in db.MediaText
                                         where m.MediaId == mediaId
                                         select m.Id).FirstOrDefaultAsync<string>();

                return await (from p in db.ParsedText
                              where p.MediaTextId == mediaTextId
                              select p).ToListAsync<ParsedText>();

            }
        }
    }
}
