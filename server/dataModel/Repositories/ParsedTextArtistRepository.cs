using System;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public class ParsedTextArtistRepository : BaseRepository, IParsedTextArtistRepository
    {
        public ParsedTextArtistRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<ParsedTextArtist> AddAsync(ParsedTextArtist parsedTextArtist)
        {
            using (var db = base._dbContextFactory.Create())
            {
                parsedTextArtist.Created = DateTime.UtcNow;
                await db.ParsedTextArtist.AddAsync(parsedTextArtist);
                await db.SaveChangesAsync();

                return parsedTextArtist;
            }
        }
    }
}
