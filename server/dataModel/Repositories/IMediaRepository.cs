using System.Threading.Tasks;

namespace dataModel.Repositories
{
    interface IMediaRepository
    {
        Task<string> AddMedia();
    }
}
