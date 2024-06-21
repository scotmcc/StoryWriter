using Microsoft.EntityFrameworkCore;
using StoryWriter.Data.Entities;

namespace StoryWriter.Data
{
    public class StoryWriterContext(DbContextOptions<StoryWriterContext> options) : DbContext(options)
    {
        public DbSet<ItemEntity> Items { get; set; } = default!;
        public DbSet<CharacterEntity> Characters { get; set; } = default!;
        public DbSet<SceneEntity> Scenes { get; set; } = default!;
        public DbSet<StoryEntity> Stories { get; set; } = default!;
        public DbSet<ChapterEntity> Chapters { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Story Entity
            modelBuilder.Entity<StoryEntity>()
                .HasMany(s => s.Characters)
                .WithOne(c => c.Story);
            modelBuilder.Entity<StoryEntity>()
                .HasMany(s => s.Items)
                .WithOne(i => i.Story);
            modelBuilder.Entity<StoryEntity>()
                .HasMany(s => s.Scenes)
                .WithOne(e => e.Story);
            modelBuilder.Entity<StoryEntity>()
                .HasMany(s => s.Chapters)
                .WithOne(c => c.Story);
            modelBuilder.Entity<StoryEntity>()
                .HasMany(s => s.Locations)
                .WithOne(l => l.Story);

            // Character Entity
            modelBuilder.Entity<CharacterEntity>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Character);
            modelBuilder.Entity<CharacterEntity>()
                .HasMany(c => c.Chapters)
                .WithMany(c => c.Characters);

            // Scene Entity
            modelBuilder.Entity<SceneEntity>()
                .HasMany(e => e.Characters)
                .WithMany(c => c.Scenes);
            modelBuilder.Entity<SceneEntity>()
                .HasMany(e => e.Chapters)
                .WithMany(c => c.Scenes);
            modelBuilder.Entity<SceneEntity>()
                .HasMany(l => l.Locations)
                .WithMany(l => l.Scenes);
            modelBuilder.Entity<SceneEntity>()
                .HasMany(i => i.Items)
                .WithMany(i => i.Scenes);
            modelBuilder.Entity<SceneEntity>()
                .HasIndex(e => e.Sequence)
                .IsUnique();
        }
    }
}