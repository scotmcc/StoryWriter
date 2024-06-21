using Microsoft.EntityFrameworkCore;
using StoryWriter.Data;
using StoryWriter.Data.Entities;

namespace StoryWriter.Services
{
    public class SceneService(StoryWriterContext context) : BaseService<SceneEntity>(context)
    {
        public async Task<SceneEntity> GetSceneWithDetailsAsync(Guid id)
        {
            return await _context.Set<SceneEntity>()
                .Include(s => s.Characters)
                .Include(s => s.Items)
                .Include(s => s.Chapters)
                .Include(s => s.Locations)
                .FirstOrDefaultAsync(s => s.Id == id)
                ?? throw new KeyNotFoundException();
        }
        public async Task<IEnumerable<CharacterEntity>> GetCharactersAsync(Guid sceneId)
        {
            return await _context.Set<CharacterEntity>()
                .Where(c => c.Scenes.Any(e => e.Id == sceneId))
                .ToListAsync();
        }

        public async Task<SceneEntity> AddCharacterToSceneAsync(Guid sceneId, CharacterEntity character)
        {
            var scene = await GetByIdAsync(sceneId);
            character.Scenes.Add(scene);
            _context.Set<CharacterEntity>().Update(character);
            await _context.SaveChangesAsync();
            return scene;
        }

        public async Task<SceneEntity> RemoveCharacterFromSceneAsync(Guid sceneId, Guid characterId)
        {
            var scene = await GetByIdAsync(sceneId);
            var character = await _context.Set<CharacterEntity>().FindAsync(characterId)
                           ?? throw new KeyNotFoundException();
            if (!character.Scenes.Any(e => e.Id == sceneId))
            {
                throw new KeyNotFoundException();
            }
            character.Scenes.Remove(scene);
            _context.Set<CharacterEntity>().Update(character);
            await _context.SaveChangesAsync();
            return scene;
        }

        public async Task<IEnumerable<ChapterEntity>> GetChaptersAsync(Guid sceneId)
        {
            return await _context.Set<ChapterEntity>()
                .Where(c => c.Scenes.Any(e => e.Id == sceneId))
                .ToListAsync();
        }

        public async Task<SceneEntity> AddChapterToSceneAsync(Guid sceneId, ChapterEntity chapter)
        {
            var scene = await GetByIdAsync(sceneId);
            chapter.Scenes.Add(scene);
            _context.Set<ChapterEntity>().Update(chapter);
            await _context.SaveChangesAsync();
            return scene;
        }
    }
}
