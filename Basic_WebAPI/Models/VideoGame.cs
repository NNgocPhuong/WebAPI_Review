namespace Basic_WebAPI.Models
{
    public class VideoGame
    {
        public int VideoGameId { get; set; }
        public required string Name { get; set; }
        public int? DeveloperId { get; set; }
        public Developer? Developer { get; set; }
        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public VideoGameDetail? VideoGameDetail { get; set; }
    }
}
