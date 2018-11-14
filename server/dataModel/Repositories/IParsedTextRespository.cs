using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface IParsedTextRespository
    {
        Task<bool> AddParsedText(IEnumerable<ParsedText> parsedText);
    }
}
