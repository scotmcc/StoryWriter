using Microsoft.EntityFrameworkCore;
using StoryWriter.Data;
using StoryWriter.Data.Entities;

namespace StoryWriter.Services
{
    public class LocationService(StoryWriterContext context) : BaseService<LocationEntity>(context)
    {
        public async Task<IEnumerable<SceneEntity>> GetScenesAsync(Guid locationId)
        {
            return await _context.Set<SceneEntity>()
                .Where(e => e.Locations.Any(l => l.Id == locationId)).ToListAsync();
        }

        public async Task<LocationEntity> AddSceneToLocationAsync(Guid locationId, SceneEntity scene)
        {
            var location = await _context.Set<LocationEntity>().FindAsync(locationId)
                           ?? throw new KeyNotFoundException();
            _context.Set<SceneEntity>().Add(scene);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<LocationEntity> RemoveSceneFromLocationAsync(Guid locationId, Guid sceneId)
        {
            var location = await GetByIdAsync(locationId);
            var scene = await _context.Set<SceneEntity>().FindAsync(sceneId)
                           ?? throw new KeyNotFoundException();
            if (!scene.Locations.Any(l => l.Id == locationId))
            {
                throw new KeyNotFoundException();
            }
            scene.Locations.Remove(location);
            _context.Set<SceneEntity>().Update(scene);
            await _context.SaveChangesAsync();
            return location;
        }
    }
}