using dataModel;
using System.Collections.Generic;

namespace bl
{
    public interface IIndexManager
    {
        void AddUpdateLuceneIndex(IEnumerable<ParsedText> dataToIndex);
        IEnumerable<ParsedText> Search(string searchQuery, string searchField = null);
    }
}
