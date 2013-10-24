using Orchard.ContentManagement.Records;

namespace Orchard.Learning.Models
{
    public class TopicPartRecord : ContentPartRecord
    {
        public virtual string TopicName { get; set; }
        public virtual string TopicDescription { get; set; }
    }
}