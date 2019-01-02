using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface IParsedTextArtistRepository
    {
        Task<ParsedTextArtist> AddAsync(ParsedTextArtist parsedTextArtist);
    }
}
