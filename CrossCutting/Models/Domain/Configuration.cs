namespace BlogServer.CrossCutting.Models.Domain
{
    public class Configuration
    {
        public int Id { get; set; }
        public string? Section { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}
