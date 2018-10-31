using System;

namespace dataModel
{
    public class ParsedText
    {
        public string Id { get; set; }
        public string MediaTextId { get; set; }
        public string Text { get; set; }
        public string ArtistId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
