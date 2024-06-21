using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StoryWriter.Data.Entities
{
    [Table("Chapters")]
    public class ChapterEntity : StoryElement
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        // The content of the chapter
        [Column(TypeName = "TEXT")]
        public string Content { get; set; } = string.Empty;
        // One or more scenes that occur in this chapter
        [JsonIgnore]
        public ICollection<SceneEntity> Scenes { get; set; } = [];
        // One or more characters that appear in this chapter
        [JsonIgnore]
        public ICollection<CharacterEntity> Characters { get; set; } = [];
    }
}