using System;

namespace dataModel
{
    public class Media
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Season { get; set; }
        public string Episode { get; set; }
        public string Type { get; set; }
        public string Image {get; set; }
        public string Keywords { get; set; }
        public string Status { get; set; }
        public string ExternalLink { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
}
