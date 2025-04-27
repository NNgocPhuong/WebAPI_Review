using Basic_WebAPI.DTO;
using Basic_WebAPI.IService;
using Basic_WebAPI.Models;
using Basic_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Basic_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly IVideoGameService context;
        public VideoGameController(IVideoGameService videoGame) { context = videoGame; }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var videoGames = await context.GetVideoGameListAsync(); 
            return Ok(videoGames);
        }
        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var videoGame = await context.GetVideoGameByIdAsync(id);
            return Ok(videoGame);
        }
        [HttpPost]
        public async Task<IActionResult> Add(VideoGameDto videoGame)
        {
            if(ModelState.IsValid)
            {
                VideoGame game = new VideoGame() 
                { 
                    Name = videoGame.Name,
                    PublisherId = videoGame.PublisherId,
                    DeveloperId = videoGame.DeveloperId
                };
                var result = await context.CreateVideoGameAsync(game);
                if (result == null)
                {
                    return BadRequest("Game này da ton tai");
                }
                return CreatedAtAction(nameof(Add), game);
            }    
            return BadRequest();
        }
    }
}
