namespace Basic_WebAPI.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public required string Name { get; set; }
        public string? Region { get; set; }
    }
}
