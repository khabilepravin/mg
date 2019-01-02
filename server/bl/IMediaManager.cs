using dataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bl
{
    public interface IMediaManager
    {
        Task<Media> AddMediaParsedAsync(Media media, MediaText mediaText);
        Task<IEnumerable<Media>> Search(string searchText);
    }
}
