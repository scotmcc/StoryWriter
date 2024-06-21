using Microsoft.EntityFrameworkCore;
using StoryWriter.Data;
using StoryWriter.Data.Entities;

namespace StoryWriter.Services
{
    public class ChapterService(StoryWriterContext context) : BaseService<ChapterEntity>(context)
    {
        public async Task<ChapterEntity> GetChapterWithDetailsAsync(Guid id)
        {
            return await _context.Set<ChapterEntity>()
                .Include(c => c.Characters)
                .Include(c => c.Scenes)
                .FirstOrDefaultAsync(c => c.Id == id)
                ?? throw new KeyNotFoundException();
        }
        public async Task<IEnumerable<SceneEntity>> GetScenesAsync(Guid chapterId)
        {
            return await _context.Set<SceneEntity>()
                .Where(e => e.Chapters.Any(c => c.Id == chapterId))
                .ToListAsync();
        }
        public async Task<ChapterEntity> AddSceneToChapterAsync(Guid chapterId, SceneEntity @scene)
        {
            var chapter = await GetByIdAsync(chapterId);
            @scene.Chapters.Add(chapter);
            _context.Set<SceneEntity>().Update(@scene);
            await _context.SaveChangesAsync();
            return chapter;
        }
        public async Task<ChapterEntity> RemoveSceneFromChapterAsync(Guid chapterId, Guid sceneId)
        {
            var chapter = await GetByIdAsync(chapterId);
            var @scene = await _context.Set<SceneEntity>().FindAsync(sceneId)
                        ?? throw new KeyNotFoundException();
            if (!@scene.Chapters.Any(c => c.Id == chapterId))
            {
                throw new KeyNotFoundException();
            }
            @scene.Chapters.Remove(chapter);
            _context.Set<SceneEntity>().Update(@scene);
            await _context.SaveChangesAsync();
            return chapter;
        }
    }
}
