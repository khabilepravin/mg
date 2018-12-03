using dataModel;
using indexing;
using System.Collections.Generic;

namespace bl
{
    public class IndexManager : IIndexManager
    {
        private readonly ITextIndexing _textIndexing;
        public IndexManager(ITextIndexing textIndexing)
        {
            _textIndexing = textIndexing;
        }

        public void AddUpdateLuceneIndex(IEnumerable<ParsedText> dataToIndex, string titleId)
        {
            _textIndexing.AddUpdateLuceneIndex(dataToIndex, titleId);
        }
    }
}
