using Basic_WebAPI.IService;
using Basic_WebAPI.Models;
using Basic_WebAPI.Repositories;

namespace Basic_WebAPI.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly VideoGameRepository _videoGameRepository;
        public VideoGameService(VideoGameRepository videoGameRepository) {
            _videoGameRepository = videoGameRepository;
        }
        public async Task<VideoGame?> CreateVideoGameAsync(VideoGame videoGame)
        {
            return await _videoGameRepository.Create(videoGame);
        }

        public async Task<VideoGame?> GetVideoGameByIdAsync(int id)
        {
            return await _videoGameRepository.GetById(id);
        }

        public async Task<List<VideoGame>> GetVideoGameListAsync()
        {
            return await _videoGameRepository.GetAll();
        }

        public async Task<VideoGame?> UpdateVideoGameAsync(int id, VideoGame videoGame)
        {
            return await _videoGameRepository.Update(id, videoGame);
        }
    }
}
