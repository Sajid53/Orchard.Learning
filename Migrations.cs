using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Orchard.Learning
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            // Creating the Topics ContentType
            ContentDefinitionManager.AlterTypeDefinition("Topics", builder => builder
                .WithPart("TitlePart")
                .WithPart("CommonPart")
                .WithPart("AutoroutePart", partbuilder => partbuilder.WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
                .WithPart("BodyPart")
                .Creatable()
                .Draftable());

            // Creating the corresponding table for the TopicPartRecord
            SchemaBuilder.CreateTable("TopicPartRecord", table => table
                .ContentPartRecord()
                .Column<string>("TopicName", col => col.WithLength(100))
                .Column<string>("TopicDescription", col => col.WithLength(250)));

            ContentDefinitionManager.AlterTypeDefinition("Topics", builder => builder
                .WithPart("TopicPart")); // Attached the TopicPart to the Topics Content Type
            return 1;
        }

        public int UpdateFrom1() { // Making some AutorouteSettings for the AutoroutePart
            ContentDefinitionManager.AlterTypeDefinition("Topics", builder => builder
                .WithPart("AutoroutePart", partBuilder => 
                 partBuilder
                  .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                  .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit","false")
                  .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name: 'Topic Title', Pattern: 'topics/{Content.Slug}',Description: 'topics/topic-title'}]")));
            return 2;
        }
    }
}