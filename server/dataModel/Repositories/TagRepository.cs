using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<TagMaster> AddTag(TagMaster tagMaster)
        {
            using (var db = base._dbContextFactory.Create())
            {
                tagMaster.Created = DateTime.UtcNow;
                await db.TagMaster.AddAsync(tagMaster);
                await db.SaveChangesAsync();
                return tagMaster;
            }
        }

        public async Task<int> AddTagsForMedia(IEnumerable<string> tagIds, string mediaId)
        {
            int affectedRows = 0;
            using (var db = base._dbContextFactory.Create())
            {
                foreach(var tagId in tagIds)
                {
                    var mediaTag = new MediaTag { TagId = tagId, MediaId = mediaId };
                    await db.MediaTag.AddAsync(mediaTag);
                    affectedRows++;
                }

                await db.SaveChangesAsync();
                return affectedRows;
            }
        }

        public async Task<IEnumerable<TagMaster>> GetTags(string tagBegging)
        {
            using (var db = base._dbContextFactory.Create())
            {
                return await (from tm in db.TagMaster
                              select tm).ToListAsync<TagMaster>();
            }
        }

        public async Task<IEnumerable<TagMaster>> GetTagsForMedia(string mediaId)
        {
            using (var db = base._dbContextFactory.Create())
            {
                var mediaTags = await (from mt in db.MediaTag
                                       where mt.MediaId == mediaId
                                       select mt.TagId).ToListAsync<string>();

                return await (from tm in db.TagMaster
                              where mediaTags.Contains(tm.Id)
                              select tm).ToListAsync<TagMaster>();
            }
        }
    }
}
