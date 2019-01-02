using dataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public interface ITagManager
    {
        Task<TagMaster> AddTag(string tag);
        Task<int> AddTagsForMedia(IEnumerable<string> tagIds, string mediaId);
        Task<IEnumerable<TagMaster>> GetTags(string tagBegging);
        Task<IEnumerable<TagMaster>> GetTagsForMedia(string mediaId);
    }
}
