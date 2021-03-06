﻿using System;
using System.Threading.Tasks;

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
    }
}
