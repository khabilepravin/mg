using dataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public interface ITextManager
    {
        Task<bool> GroupText(IEnumerable<string> textIds);

        Task<IEnumerable<ParsedText>> GetPopularTextForMedia(string mediaId);
        Task<IEnumerable<ParsedText>> GetSurroundingText(string textId, int proximity);
    }
}
