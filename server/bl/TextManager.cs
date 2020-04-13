using dataModel;
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

        public async Task<IEnumerable<ParsedText>> GetPopularTextForMedia(string mediaId)
        {
            return await _parsedTextRespository.GetFavoriteParsedTextByMediaId(mediaId);
        }

        public async Task<IEnumerable<ParsedText>> GetSurroundingText(string textId, int proximity)
        {
            var parsedText = await _parsedTextRespository.GetParsedText(textId);

            if(parsedText.SerialNumber > 0)
            {
                List<int> serialNumbers = new List<int>();

                serialNumbers.Add(parsedText.SerialNumber);

                for(int i = 1; i <= proximity; i++)
                {
                    serialNumbers.Add(parsedText.SerialNumber + i);
                }

                for (int i = proximity; i < 1; i--)
                {
                    serialNumbers.Add(parsedText.SerialNumber - i);
                }

                return await _parsedTextRespository.GetTextBySerialNumber(serialNumbers);
            }
            else
            {
                return new List<ParsedText> { parsedText };
            }
        }
    }
}
