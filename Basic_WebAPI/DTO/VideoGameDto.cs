namespace Basic_WebAPI.DTO
{
    public class VideoGameDto
    {
        public required string Name { get; set; }
        public int? DeveloperId { get; set; }
        public int? PublisherId { get; set; }
    }
}
