using Microsoft.AspNetCore.Routing.Constraints;
using System.Text.Json.Serialization;

namespace BlogServer.CrossCutting.Models.Domain
{
    public class Comments
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("postId")]
        public int PostId { get; set; }
        
        [JsonPropertyName("authorName")]
        public string? AuthorName { get; set; }
        
        [JsonPropertyName("content")]
        public string? Content { get; set; }
        
        [JsonPropertyName("dateCreated")]
        public DateTime? DateCreated { get; set; }

        [JsonPropertyName("changedAt")]
        public DateTime? ChangedAt { get; set; }
    }
}
