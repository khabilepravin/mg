using dataModel;
using System.Collections.Generic;

namespace bl
{
    public interface ISearch
    {
        IEnumerable<ParsedText> SearchText(string searchQuery, string searchField = null);
    }
}
