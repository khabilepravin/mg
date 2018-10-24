using System;

namespace dataModel
{
    public class ParsedText
    {
        public string Id { get; set; }
        public string MediaTextId { get; set; }
        public string Text { get; set; }
        public string ArtistId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
