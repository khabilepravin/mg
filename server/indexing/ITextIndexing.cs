using dataModel;
using System.Collections.Generic;

namespace indexing
{
    public interface ITextIndexing
    {
        bool IndexText(IEnumerable<ParsedText> dataToIndex);
        IEnumerable<ParsedText> SearchText(string searchString);
    }
}
