using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StoryWriter.Data.Entities
{
    [Table("Items")]
    public class ItemEntity : StoryElement
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        // The character that carries this item
        [JsonIgnore]
        public CharacterEntity Character { get; set; } = new CharacterEntity();
        // One or more scenes this item is involved in
        [JsonIgnore]
        public ICollection<SceneEntity> Scenes { get; set; } = [];
        // One or more chapters this item is involved in
        [JsonIgnore]
        public ICollection<ChapterEntity> Chapters { get; set; } = [];
        // One or more locations this item is found in
        [JsonIgnore]
        public ICollection<LocationEntity> Locations { get; set; } = [];
    }
}