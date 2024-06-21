using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StoryWriter.Data.Entities
{
    [Table("Locations")]
    public class LocationEntity : StoryElement
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<SceneEntity> Scenes = [];
        [JsonIgnore]
        public ICollection<ChapterEntity> Chapters = [];
    }
}