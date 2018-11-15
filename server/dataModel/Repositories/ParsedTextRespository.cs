using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public class ParsedTextRespository : BaseRepository, IParsedTextRespository
    {
        public ParsedTextRespository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<bool> AddManyAsync(IEnumerable<ParsedText> parsedText)
        {
            using (var db = base._dbContextFactory.Create())
            {
                foreach(var parsedT in parsedText)
                {
                    await db.AddAsync(parsedT);
                }

                await db.SaveChangesAsync();
                return true;
            }

        }
    }
}
