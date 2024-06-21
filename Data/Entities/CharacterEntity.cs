using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StoryWriter.Data.Entities
{
    [Table("Characters")]
    public class CharacterEntity : StoryElement
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        // One or more items carried by this character
        [JsonIgnore]
        public ICollection<ItemEntity> Items { get; set; } = [];
        // One or more scenes related to this character
        [JsonIgnore]
        public ICollection<SceneEntity> Scenes { get; set; } = [];
        // One or more chapters related to this character
        [JsonIgnore]
        public ICollection<ChapterEntity> Chapters { get; set; } = [];
    }
}