using Microsoft.EntityFrameworkCore;
using StoryWriter.Data;
using StoryWriter.Data.Entities;

namespace StoryWriter.Services
{
    public class ItemService(StoryWriterContext context) : BaseService<ItemEntity>(context)
    {
        public async Task<ItemEntity> GetItemWithDetailsAsync(Guid id)
        {
            return await _context.Set<ItemEntity>()
                .Include(i => i.Chapters)
                .Include(i => i.Scenes)
                .Include(i => i.Chapters)
                .FirstOrDefaultAsync(i => i.Id == id)
                ?? throw new KeyNotFoundException();
        }
        public async Task<IEnumerable<CharacterEntity>> GetCharactersAsync(Guid itemId)
        {
            return await _context.Set<CharacterEntity>()
                .Where(c => c.Items.Any(i => i.Id == itemId))
                .ToListAsync();
        }

        public async Task<ItemEntity> AddCharacterToItemAsync(Guid itemId, CharacterEntity character)
        {
            var item = await GetByIdAsync(itemId);
            character.Items.Add(item);
            _context.Set<CharacterEntity>().Add(character);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<ItemEntity> RemoveCharacterFromItemAsync(Guid itemId, Guid characterId)
        {
            var item = await GetByIdAsync(itemId);
            var character = await _context.Set<CharacterEntity>().FindAsync(characterId)
                           ?? throw new KeyNotFoundException();
            if (!character.Items.Any(i => i.Id == itemId))
            {
                throw new KeyNotFoundException();
            }
            character.Items.Remove(item);
            _context.Set<CharacterEntity>().Update(character);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
