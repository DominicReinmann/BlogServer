using BlogServer.CrossCutting.Logger;
using BlogServer.Logic.Manager.UserManagement;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace BlogServer.Logic.Encryption
{
    public class EncryptionService : IEncryptionService
    {
        private readonly ILog _log;
        private readonly IUserManager _manager;
        private protected byte[] _encryptionKey;

        public EncryptionService(ILog log, IUserManager manager)
        {
            _log = log;
            _manager = manager;
        }

        public string HashPassword(string pw)
        {
            try
            {
                byte[] salt = GenerateSalt();
                byte[] hashedPassword = HashStringToBytes(pw, salt);
                string saltBase64 = Convert.ToBase64String(salt);
                string hashedPasswordBase64 = Convert.ToBase64String(hashedPassword);
                return $"{saltBase64}:{hashedPasswordBase64}";
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error hashing password: {ex.Message}");
                return string.Empty;
            }
        }

        public bool CheckPassword(string pw, string username)
        {
            try
            {
                var dbPassword = _manager.GetAll().Where(x => x.Username == username).Select(x => x.Password).FirstOrDefault();
                if (string.IsNullOrEmpty(dbPassword))
                {
                    return false;
                }

                string[] passwordParts = dbPassword.Split(':');
                if (passwordParts.Length != 2)
                {
                    return false;
                }

                string saltBase64 = passwordParts[0];
                string hashedPasswordBase64 = passwordParts[1];

                byte[] salt = Convert.FromBase64String(saltBase64);
                byte[] hashedPassword = HashStringToBytes(pw, salt);
                string hashedPasswordBase64Check = Convert.ToBase64String(hashedPassword);

                return hashedPasswordBase64 == hashedPasswordBase64Check;
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error checking password: {ex.Message}");
                return false;
            }
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private byte[] HashStringToBytes(string pw, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(pw, salt, 10000))
            {
                return pbkdf2.GetBytes(32);
            }
        }
    }
}
