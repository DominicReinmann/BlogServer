using System.Text.Json.Serialization;

namespace BlogServer.CrossCutting.Models.Domain
{
    public class Posts
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("author")]
        public int Author { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("tags")]
        public string? Tags { get; set; }

        [JsonPropertyName("dateCreated")]
        public DateTime DateCreated { get; set; }
    }
}
