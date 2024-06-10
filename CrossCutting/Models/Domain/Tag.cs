using System.Text.Json.Serialization;

namespace BlogServer.CrossCutting.Models.Domain
{
    public class Tag
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
