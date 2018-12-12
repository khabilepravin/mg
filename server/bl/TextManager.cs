using dataModel.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public class TextManager : ITextManager
    {
        private readonly IParsedTextRespository _parsedTextRespository = null;
        public TextManager(IParsedTextRespository parsedTextRespository)
        {
            _parsedTextRespository = parsedTextRespository;
        }

        public async Task<bool> GroupText(IEnumerable<string> textIds)
        {
            var groupId = Guid.NewGuid();

            var parsedTextCollection = await _parsedTextRespository.GetParsedTextByIds(textIds);

            foreach(var textObject in parsedTextCollection)
            {
                textObject.GroupId = groupId.ToString();
            }
           
            return await _parsedTextRespository.UpdateManyAsync(parsedTextCollection);
            
        }
    }
}
