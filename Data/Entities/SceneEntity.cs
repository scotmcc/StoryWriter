using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StoryWriter.Data.Entities
{
    [Table("Scenes")]
    public class SceneEntity : StoryElement
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Sequence { get; set; } = 0;
        // One or more characters involved in this scene
        [JsonIgnore]
        public ICollection<CharacterEntity> Characters { get; set; } = [];
        // One or more chapters this scene occurs in
        [JsonIgnore]
        public ICollection<ChapterEntity> Chapters { get; set; } = [];
        // One or more locations this scene occurs in
        [JsonIgnore]
        public ICollection<LocationEntity> Locations { get; set; } = [];
        // One or more items involved in this scene
        [JsonIgnore]
        public ICollection<ItemEntity> Items { get; set; } = [];
    }
}