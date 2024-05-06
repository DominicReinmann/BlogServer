namespace BlogServer.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken();
    }
}