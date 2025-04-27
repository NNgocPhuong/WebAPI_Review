using Basic_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Basic_WebAPI.Data
{
    public class VideoGameDbContext : DbContext
    {
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<VideoGameDetail> VideoGameDetails { get; set; }
        public VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : base(options)
        {
        }

        protected VideoGameDbContext()
        {
        }
    }
}
