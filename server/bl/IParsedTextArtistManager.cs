using dataModel;
using System.Threading.Tasks;

namespace bl
{
    public interface IParsedTextArtistManager
    {
        Task<ParsedTextArtist> AddAsync(ParsedTextArtist parsedTextArtist);
    }
}
