using Basic_WebAPI.Data;
using Basic_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Basic_WebAPI.Repositories
{
    public class VideoGameRepository
    {
        private readonly VideoGameDbContext _dbContext;
        public VideoGameRepository(VideoGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<VideoGame>> GetAll()
        {
            return await _dbContext.VideoGames
                .Include(g => g.Developer)
                .Include(g => g.Publisher)
                .Include(g => g.VideoGameDetail)
                .ToListAsync();
        }
        public async Task<VideoGame?> GetById(int id)
        {
            return await _dbContext.VideoGames
                .Include(g => g.Developer)
                .Include(g => g.Publisher)
                .Include(g => g.VideoGameDetail)
                .SingleOrDefaultAsync(g => g.VideoGameId == id);
        }
        public async Task<VideoGame?> Create(VideoGame videoGame)
        {
            var game = _dbContext.VideoGames.SingleOrDefault(
                g => g.Name == videoGame.Name 
            && g.Publisher == videoGame.Publisher
            && g.Developer == videoGame.Developer
            );
            if (videoGame == null)
            {
                return null;
            }
            if (game != null)
            {
                return null;                
            }
            await _dbContext.VideoGames.AddAsync(videoGame);
            await _dbContext.SaveChangesAsync();
            return videoGame;
        }
        public async Task<VideoGame?> Update(int id, VideoGame videoGame)
        {
            var Old_videoGame = _dbContext.VideoGames.Find(id);
            if (Old_videoGame != null && id == videoGame.VideoGameId)
            {
                Old_videoGame.Name = videoGame.Name;
                Old_videoGame.Publisher = videoGame.Publisher;
                Old_videoGame.Developer = videoGame.Developer;
                _dbContext.VideoGames.Update(Old_videoGame);
                await _dbContext.SaveChangesAsync();
                return videoGame;
            }
            return null;
        }
    }
}
