using dataModel;
using dataModel.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public class TagManager : ITagManager
    {
        private readonly ITagRepository _tagRepository;
        public TagManager(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<TagMaster> AddTag(string tag)
        {
            var tagRecord = new TagMaster { Name = tag, Description = tag };

            return await _tagRepository.AddTag(tagRecord);
        }

        public async Task<int> AddTagsForMedia(IEnumerable<string> tagIds, string mediaId)
        {
            return await _tagRepository.AddTagsForMedia(tagIds, mediaId);
        }

        public async Task<IEnumerable<TagMaster>> GetTags(string tagBegging)
        {
            return await _tagRepository.GetTags(tagBegging);
        }

        public async Task<IEnumerable<TagMaster>> GetTagsForMedia(string mediaId)
        {
            return await _tagRepository.GetTagsForMedia(mediaId);
        }
    }
}
