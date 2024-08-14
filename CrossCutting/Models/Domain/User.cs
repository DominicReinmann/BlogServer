using System.Text.Json.Serialization;

namespace BlogServer.CrossCutting.Models.Domain
{
    public class User
    {
        public int Id { get; set; }
        
        [JsonPropertyName("userName")]
        public string? Username { get; set; }
        
        [JsonPropertyName("password")]
        public string? Password { get; set; }
        
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        
        [JsonPropertyName("role")]
        public string? Role { get; set; }
    }
}
