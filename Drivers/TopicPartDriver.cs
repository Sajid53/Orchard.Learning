using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Learning.Models;

namespace Orchard.Learning.Drivers
{
    public class TopicPartDriver : ContentPartDriver<TopicPart> {
        protected override string Prefix {
            get { return "Topic"; }
        }

        // HttpGet
        protected override DriverResult Editor(TopicPart part, dynamic shapeHelper) {
            return ContentShape("Parts_Topic_Edit", () => shapeHelper
                .EditorTemplate(TemplateName: "Parts/Topic", Model: part, Prefix: Prefix));
        }
        // HttpPost
        protected override DriverResult Editor(TopicPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
        // Displays content on the front-end of an Orchard site
        protected override DriverResult Display(TopicPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Topic", () => shapeHelper.Parts_Topic(TopicPart: part));
        }
    }
}