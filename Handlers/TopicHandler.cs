using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Learning.Models;

namespace Orchard.Learning.Handlers
{
    public class TopicHandler : ContentHandler
    {
        public TopicHandler(IRepository<TopicPartRecord> topicRepository) {
            Filters.Add(StorageFilter.For(topicRepository));
        }
    }
}