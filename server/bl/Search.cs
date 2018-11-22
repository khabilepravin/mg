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

        public IEnumerable<ParsedText> SearchText(string searchQuery, string searchField = null)
        {
            return _textIndexing.Search(searchQuery, searchField);
        }
    }
}
