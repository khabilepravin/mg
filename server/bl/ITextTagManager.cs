using dataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public interface ITextTagManager
    {
        Task<int> AddTextTag(IEnumerable<string> tagIds, string textId);
        Task<IEnumerable<TagMaster>> GetTextTags(string textId);
    }
}
