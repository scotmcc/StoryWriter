using Microsoft.EntityFrameworkCore;
using StoryWriter.Data;
using StoryWriter.Data.Entities;

namespace StoryWriter.Services
{
    public class CharacterService(StoryWriterContext context) : BaseService<CharacterEntity>(context)
    {
        public async Task<CharacterEntity> GetCharacterWithDetailsAsync(Guid id)
        {
            return await _context.Set<CharacterEntity>()
                .Include(c => c.Items)
                .Include(c => c.Scenes)
                .Include(c => c.Chapters)
                .FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new KeyNotFoundException();
        }
        public async Task<IEnumerable<ItemEntity>> GetItemsAsync(Guid characterId)
        {
            return await _context.Set<ItemEntity>()
                .Where(i => i.Character.Id == characterId)
                .ToListAsync();
        }
        public async Task<CharacterEntity> AddItemToCharacterAsync(Guid characterId, ItemEntity item)
        {
            var character = await GetByIdAsync(characterId);
            item.Character = character;
            _context.Set<ItemEntity>().Update(item);
            await _context.SaveChangesAsync();
            return character;
        }
        public async Task<CharacterEntity> RemoveItemFromCharacterAsync(Guid characterId, Guid itemId)
        {
            var character = await GetByIdAsync(characterId);
            var item = await _context.Set<ItemEntity>().FindAsync(itemId)
                        ?? throw new KeyNotFoundException();
            if (item.Character.Id != characterId)
            {
                throw new KeyNotFoundException();
            }
            item.Character = new CharacterEntity();
            _context.Set<ItemEntity>().Update(item);
            await _context.SaveChangesAsync();
            return character;
        }
        public async Task<IEnumerable<SceneEntity>> GetScenesAsync(Guid characterId)
        {
            return await _context.Set<SceneEntity>()
                .Where(e => e.Characters.Any(c => c.Id == characterId))
                .ToListAsync();
        }
        public async Task<CharacterEntity> AddSceneToCharacterAsync(Guid characterId, SceneEntity @scene)
        {
            var character = await GetByIdAsync(characterId);
            @scene.Characters.Add(character);
            _context.Set<SceneEntity>().Update(@scene);
            await _context.SaveChangesAsync();
            return character;
        }
        public async Task<CharacterEntity> RemoveSceneFromCharacterAsync(Guid characterId, Guid sceneId)
        {
            var character = await GetByIdAsync(characterId);
            var @scene = await _context.Set<SceneEntity>().FindAsync(sceneId)
                        ?? throw new KeyNotFoundException();
            if (!@scene.Characters.Any(c => c.Id == characterId))
            {
                throw new KeyNotFoundException();
            }
            @scene.Characters.Remove(character);
            _context.Set<SceneEntity>().Update(@scene);
            await _context.SaveChangesAsync();
            return character;
        }
    }
}
