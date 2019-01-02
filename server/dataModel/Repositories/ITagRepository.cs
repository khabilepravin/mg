using System.Collections.Generic;
using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface ITagRepository
    {
        Task<TagMaster> AddTag(TagMaster tagMaster);
        Task<int> AddTagsForMedia(IEnumerable<string> tagIds, string mediaId);
        Task<IEnumerable<TagMaster>> GetTags(string tagBegging);
        Task<IEnumerable<TagMaster>> GetTagsForMedia(string mediaId);
    }
}
