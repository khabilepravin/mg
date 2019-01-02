using System.Threading.Tasks;
using dataModel;
using dataModel.Repositories;

namespace bl
{
    public class ParsedTextArtistManager : IParsedTextArtistManager
    {
        private readonly IParsedTextArtistRepository _parsedTextArtistRepository;
        public ParsedTextArtistManager(IParsedTextArtistRepository parsedTextArtistRepository)
        {
            _parsedTextArtistRepository = parsedTextArtistRepository;
        }

        public async Task<ParsedTextArtist> AddAsync(ParsedTextArtist parsedTextArtist)
        {
            return await _parsedTextArtistRepository.AddAsync(parsedTextArtist);
        }
    }
}
