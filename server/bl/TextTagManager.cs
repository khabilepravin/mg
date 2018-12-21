using dataModel;
using dataModel.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public class TextTagManager : ITextTagManager
    {
        private readonly ITextTagRepository _textTagRepository;
        public TextTagManager(ITextTagRepository textTagRepository)
        {
            _textTagRepository = textTagRepository;
        }

        public async Task<int> AddTextTag(IEnumerable<string> tagIds, string textId)
        {
            var i = 0;
            foreach(var tagId in tagIds)
            {
                var textTag = new TextTag { TagId = tagId, ParsedTextId = textId };

                await _textTagRepository.AddTextTag(textTag);
                i++;
            }

            return i;
        }

        public async Task<IEnumerable<TagMaster>> GetTextTags(string textId)
        {
            return await _textTagRepository.GetTextTags(textId);
        }
    }
}
