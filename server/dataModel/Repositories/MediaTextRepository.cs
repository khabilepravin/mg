using System.Threading.Tasks;

namespace dataModel.Repositories
{
    public class MediaTextRepository : BaseRepository, IMediaTextRespository
    {
        public MediaTextRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }
        public async Task<MediaText> AddAsync(MediaText mediaText)
        {
            using (var db = base._dbContextFactory.Create())
            {
                await db.MediaText.AddAsync(mediaText);
                await db.SaveChangesAsync();
                return mediaText;
            }
        }
    }
}
