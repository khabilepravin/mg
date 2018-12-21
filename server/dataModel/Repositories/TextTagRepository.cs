using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dataModel.Repositories
{
    public class TextTagRepository : BaseRepository, ITextTagRepository
    {
        public TextTagRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<TextTag> AddTextTag(TextTag textTag)
        {
            using (var db = base._dbContextFactory.Create())
            {
                await db.TextTag.AddAsync(textTag);
                await db.SaveChangesAsync();
                return textTag;
            }
        }

        public async Task<IEnumerable<TagMaster>> GetTextTags(string textId)
        {
            using (var db = base._dbContextFactory.Create())
            {
                var parsedTextIds = await (from m in db.TextTag
                                           where m.ParsedTextId == textId
                                           select m.TagId).ToListAsync<string>();

                return await (from t in db.TagMaster
                            where parsedTextIds.Contains(t.Id)
                            select t).ToListAsync<TagMaster>();
            }
        }
    }
}
