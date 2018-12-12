using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public interface ITextManager
    {
        Task<bool> GroupText(IEnumerable<string> textIds);
    }
}
