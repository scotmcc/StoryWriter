using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StoryWriter.Data.Entities
{
    public enum Genre
    {
        Fantasy,
        SciFi,
        Horror,
        Romance,
        Mystery,
        Thriller,
        Comedy,
        Drama,
        Action,
        Adventure,
        Historical,
        Erotica,
        NonFiction,
        Western,
        Other
    }
    [Table("Stories")]
    public class StoryEntity : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public Genre Genre { get; set; } = Genre.Other;
        public string Description { get; set; } = string.Empty;
        // One or more characters in the story
        [JsonIgnore]
        public ICollection<CharacterEntity> Characters { get; set; } = [];
        // One or more items in the story
        [JsonIgnore]
        public ICollection<ItemEntity> Items { get; set; } = [];
        // One or more scenes in the story
        [JsonIgnore]
        public ICollection<SceneEntity> Scenes { get; set; } = [];
        // One or more chapters in the story
        [JsonIgnore]
        public ICollection<ChapterEntity> Chapters { get; set; } = [];
        // One or more locations in the story
        [JsonIgnore]
        public ICollection<LocationEntity> Locations { get; set; } = [];
    }
    public class StoryElement : BaseEntity
    {
        // The story this element belongs to
        [JsonIgnore]
        public StoryEntity Story { get; set; } = new();
    }
}