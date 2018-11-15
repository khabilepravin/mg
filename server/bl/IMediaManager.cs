using dataModel;
using System.Threading.Tasks;

namespace bl
{
    public interface IMediaManager
    {
        Task<Media> AddMediaParsedAsync(Media media, MediaText mediaText);
    }
}
