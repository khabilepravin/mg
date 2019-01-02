using System.Collections.Generic;

namespace server.RequestTypes
{
    public class AddTagToMediaRequest
    {
        public IEnumerable<string> TagIds { get; set; }
        public string MediaId { get; set; }
    }
}