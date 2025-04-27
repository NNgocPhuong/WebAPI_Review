using Basic_WebAPI.Models;

namespace Basic_WebAPI.IService
{
    public interface IVideoGameService
    {
        Task<List<VideoGame>> GetVideoGameListAsync();
        Task<VideoGame?> GetVideoGameByIdAsync(int id);
        Task<VideoGame?> CreateVideoGameAsync(VideoGame videoGame);
        Task<VideoGame?> UpdateVideoGameAsync(int id, VideoGame videoGame);
    }
}
