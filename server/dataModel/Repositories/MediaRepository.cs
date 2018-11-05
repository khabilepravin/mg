using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public class MediaRepository : BaseRepository, IMediaRepository
    {
        public MediaRepository()
        {

        }

        public Task<string> AddMedia()
        {
            throw new System.NotImplementedException();
        }
    }
}
