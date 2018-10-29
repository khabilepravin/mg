using System;

namespace dataModel
{
    public class MediaArtist
    {
        public string Id { get; set; }
        public string MediaId { get; set; }
        public string Name { get; set; }
        public string PersonName { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string ExternalLink { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
