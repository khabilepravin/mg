using System;

namespace dataModel
{
    public class UserFavorite
    {
        public string Id { get; set; }
        public string ParsedTextId { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
