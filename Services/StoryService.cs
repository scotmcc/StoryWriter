using Microsoft.EntityFrameworkCore;
using StoryWriter.Data;
using StoryWriter.Data.Entities;

namespace StoryWriter.Services
{
    public class StoryService(StoryWriterContext context) : BaseService<StoryEntity>(context)
    {
        public async Task<StoryEntity> GetStoryWithDetailsAsync(Guid id)
        {
            return await _context.Set<StoryEntity>()
                .Include(s => s.Characters)
                .Include(s => s.Items)
                .Include(s => s.Scenes)
                .Include(s => s.Chapters)
                .Include(s => s.Locations)
                .FirstOrDefaultAsync(s => s.Id == id)
                ?? throw new KeyNotFoundException();
        }
        public async Task<IEnumerable<CharacterEntity>> GetCharactersAsync(Guid storyId)
        {
            return await _context.Set<CharacterEntity>()
                .Where(c => c.Story.Id == storyId)
                .ToListAsync();
        }

        public async Task<StoryEntity> AddCharacterToStoryAsync(Guid storyId, CharacterEntity character)
        {
            var story = await GetByIdAsync(storyId);
            character.Story = story;
            _context.Set<CharacterEntity>().Add(character);
            await _context.SaveChangesAsync();
            return story;
        }

        public async Task<StoryEntity> RemoveCharacterFromStoryAsync(Guid storyId, Guid characterId)
        {
            var story = await GetByIdAsync(storyId);
            var character = await _context.Set<CharacterEntity>().FindAsync(characterId)
                           ?? throw new KeyNotFoundException();
            if (character.Story.Id != storyId)
            {
                throw new KeyNotFoundException();
            }
            character.Story = new StoryEntity();
            _context.Set<CharacterEntity>().Update(character);
            await _context.SaveChangesAsync();
            return story;
        }

        public async Task<IEnumerable<ItemEntity>> GetItemsAsync(Guid storyId)
        {
            return await _context.Set<ItemEntity>()
                .Where(i => i.Story.Id == storyId)
                .ToListAsync();
        }

        public async Task<StoryEntity> AddItemToStoryAsync(Guid storyId, ItemEntity item)
        {
            var story = await GetByIdAsync(storyId);
            item.Story = story;
            _context.Set<ItemEntity>().Add(item);
            await _context.SaveChangesAsync();
            return story;
        }

        public async Task<StoryEntity> RemoveItemFromStoryAsync(Guid storyId, Guid itemId)
        {
            var story = await GetByIdAsync(storyId);
            var item = await _context.Set<ItemEntity>().FindAsync(itemId)
                       ?? throw new KeyNotFoundException();
            if (item.Story.Id != storyId)
            {
                throw new KeyNotFoundException();
            }
            item.Story = new StoryEntity();
            _context.Set<ItemEntity>().Update(item);
            await _context.SaveChangesAsync();
            return story;
        }

        public async Task<IEnumerable<SceneEntity>> GetScenesAsync(Guid storyId)
        {
            return await _context.Set<SceneEntity>()
                .Where(e => e.Story.Id == storyId)
                .ToListAsync();
        }

        public async Task<StoryEntity> AddSceneToStoryAsync(Guid storyId, SceneEntity @scene)
        {
            var story = await GetByIdAsync(storyId);
            @scene.Story = story;
            _context.Set<SceneEntity>().Add(@scene);
            await _context.SaveChangesAsync();
            return story;
        }

        public async Task<StoryEntity> RemoveSceneFromStoryAsync(Guid storyId, Guid sceneId)
        {
            var story = await GetByIdAsync(storyId);
            var @scene = await _context.Set<SceneEntity>().FindAsync(sceneId)
                        ?? throw new KeyNotFoundException();
            if (@scene.Story.Id != storyId)
            {
                throw new KeyNotFoundException();
            }
            @scene.Story = new StoryEntity();
            _context.Set<SceneEntity>().Update(@scene);
            await _context.SaveChangesAsync();
            return story;
        }

        public async Task<IEnumerable<ChapterEntity>> GetChaptersAsync(Guid storyId)
        {
            return await _context.Set<ChapterEntity>()
                .Where(c => c.Story.Id == storyId)
                .ToListAsync();
        }

        public async Task<StoryEntity> AddChapterToStoryAsync(Guid storyId, ChapterEntity chapter)
        {
            var story = await GetByIdAsync(storyId);
            chapter.Story = story;
            _context.Set<ChapterEntity>().Add(chapter);
            await _context.SaveChangesAsync();
            return story;
        }

        public async Task<StoryEntity> RemoveChapterFromStoryAsync(Guid storyId, Guid chapterId)
        {
            var story = await GetByIdAsync(storyId);
            var chapter = await _context.Set<ChapterEntity>().FindAsync(chapterId)
                        ?? throw new KeyNotFoundException();
            if (chapter.Story.Id != storyId)
            {
                throw new KeyNotFoundException();
            }
            chapter.Story = new StoryEntity();
            _context.Set<ChapterEntity>().Update(chapter);
            await _context.SaveChangesAsync();
            return story;
        }
    }
}
