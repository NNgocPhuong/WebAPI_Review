using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Basic_WebAPI.Models
{
    public class VideoGameDetail
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        [ForeignKey(nameof(VideoGame))]
        public int VideoGameId { get; set; }
        [JsonIgnore]
        public VideoGame? VideoGame { get; set; }
    }
}
