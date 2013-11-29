using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Learning.Models;

namespace Orchard.Learning.Handlers
{
    public class TopicHandler : ContentHandler
    {
        public TopicHandler(IRepository<TopicPartRecord> topicRepository) {
            Filters.Add(StorageFilter.For(topicRepository));
            // plumbing for saving the data in the database using the StorageFilter
        }
    }
}
