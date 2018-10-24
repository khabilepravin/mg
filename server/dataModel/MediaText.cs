using System;

namespace dataModel
{
    public class MediaText
    {
        public string Id { get; set; }
        public string MediaId { get; set; }
        public string Text { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
