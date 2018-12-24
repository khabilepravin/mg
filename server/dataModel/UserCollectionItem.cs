using System;
using System.Collections.Generic;
using System.Text;

namespace dataModel
{
    public class UserCollectionItem
    {
        public string Id { get; set; }
        public string CollectionId { get; set; }
        public string EntityId { get; set; }
        public string EntityType { get; set; }
        public DateTime Added { get; set; }
        
    }
}
