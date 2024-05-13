namespace BlogServer.Logic.Encryption
{
    public interface IEncryptionService
    {
        bool CheckPassword(string pw, string username);
        string Encryption(string pw);
    }
}