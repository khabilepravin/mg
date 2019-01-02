using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface ITextTagRepository
    {
        Task<TextTag> AddTextTag(TextTag textTag);
        Task<IEnumerable<TagMaster>> GetTextTags(string textId);
    }
}
