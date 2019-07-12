using dataModel;
using System.Collections.Generic;

namespace bl
{
    public interface ISearch
    {
        IEnumerable<dynamic> SearchText(string searchQuery, string searchField = null, string titleId= null);
    }
}
