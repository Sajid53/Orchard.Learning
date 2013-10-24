using Orchard.ContentManagement;

namespace Orchard.Learning.Models
{
    public class TopicPart : ContentPart<TopicPartRecord> {
        public string TopicName {
            get { return Record.TopicName; }
            set { Record.TopicName = value; }
        }

        public string TopicDescription {
            get { return Record.TopicDescription; }
            set { Record.TopicDescription = value; }
        }
    }
}