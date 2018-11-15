using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public interface IMediaTextRespository
    {
        Task<MediaText> AddAsync(MediaText mediaText);
    }
}
