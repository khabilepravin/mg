using dataModel;
using dataModel.Repositories;
using mgparser;
using System.Threading.Tasks;

namespace bl
{
    public class MediaManager : IMediaManager
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IMediaTextRespository _mediaTextRespository;
        private readonly IParsedTextRespository _parsedTextRespository;
        private readonly IParser _parser;
        private readonly IIndexManager _indexManager;


        public MediaManager(IMediaRepository mediaRepository,
            IMediaTextRespository mediaTextRespository,
            IParsedTextRespository parsedTextRespository,
            IParser parser,
            IIndexManager indexManager)
        {
            _mediaRepository = mediaRepository;
            _mediaTextRespository = mediaTextRespository;
            _parsedTextRespository = parsedTextRespository;
            _parser = parser;
            _indexManager = indexManager;
        }

        public async Task<Media> AddMediaParsedAsync(Media media, MediaText mediaText)
        {
            var newMedia = await _mediaRepository.AddAsync(media);

            mediaText.MediaId = newMedia.Id;

            var newMediaText = await _mediaTextRespository.AddAsync(mediaText);

            var parsedText = _parser.Parse(mediaText);

            await _parsedTextRespository.AddManyAsync(parsedText);

            _indexManager.AddUpdateLuceneIndex(parsedText);

            return newMedia;

        }
    }
}
