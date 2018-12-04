using dataModel;
using indexing;
using System.Collections.Generic;

namespace bl
{
    public class Search : ISearch
    {
        private readonly ITextIndexing _textIndexing;
        public Search(ITextIndexing textIndexing)
        {
            _textIndexing = textIndexing;
        }

        public IEnumerable<ParsedText> SearchText(string searchQuery, string searchField = null, string titleId=null)
        {
            string query = $"Text:{searchQuery} AND TitleId:{titleId}";

            return _textIndexing.Search(query, searchField, titleId);
        }
    }
}
