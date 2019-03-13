using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface IParsedTextRespository
    {
        Task<bool> AddManyAsync(IEnumerable<ParsedText> parsedText);
        Task<bool> UpdateManyAsync(IEnumerable<ParsedText> parsedTextCollection);
        Task<ParsedText> GetParsedText(string id);
        Task<IEnumerable<ParsedText>> GetParsedTextByIds(IEnumerable<string> parsedTextIds);
        Task<IEnumerable<ParsedText>> GetFavoriteParsedTextByMediaId(string mediaId);
    }
}
