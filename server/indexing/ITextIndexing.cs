using dataModel;
using System.Collections.Generic;

namespace indexing
{
    public interface ITextIndexing
    {
        void AddUpdateLuceneIndex(IEnumerable<ParsedText> dataToIndex, string titleId=null);
        IEnumerable<ParsedText> Search(string searchQuery, string titleId=null, string searchField = null);
    }
}
