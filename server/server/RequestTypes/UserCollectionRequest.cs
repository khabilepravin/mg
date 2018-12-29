using System.Collections.Generic;

namespace server.RequestTypes
{
    public class UserCollectionRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> TextIds { get; set; }
        public string CollectionType { get; set; }
    }
}
