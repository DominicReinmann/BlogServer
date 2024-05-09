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

        public string Encryption(string pw, string username)
        {
            var doo = Fuu(pw, username);
            return doo;
        }

        public bool CheckPassword(string pw, string username)
        {
            try
            {
                return CheckPasswordBool(pw, username);
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error checking Password {ex.Message}");
                return false;
            }
        }
        private string Fuu(string pw, string username)
        {
            try
            {
                _encryptionKey = Encoding.UTF8.GetBytes("thjsoeufjsnksuef");
                byte[] byteUserName = Encoding.UTF8.GetBytes(username);
                return EncryptStringToBytes(pw, byteUserName, _encryptionKey).ToString();
            }
            catch (Exception ex)
            {
                _log.ErrorLog($"Error creating password {ex.Message}");
                return string.Empty;
            }
        }

        private byte[] EncryptStringToBytes(string pw, byte[] key, byte[] IV)
        {
            if (string.IsNullOrEmpty(pw))
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrEmpty(key.ToString()))
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrEmpty(IV.ToString()))
            {
                throw new ArgumentNullException();
            }

            _log.DebugLog(key.ToString());
            _log.DebugLog(IV.ToString());

            byte[] encrypted;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = IV;

                ICryptoTransform encryptro = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptro, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(pw);
                        }
                        encrypted = ms.ToArray();
                    }
                }
            }
            return encrypted;
        }


        private bool CheckPasswordBool(string pw, string username)
        {
            try
            {
                byte[] byteUserName = Encoding.UTF8.GetBytes(username);
                _encryptionKey = Encoding.UTF8.GetBytes("");
                var temp = EncryptStringToBytes(pw, byteUserName, _encryptionKey).ToString();
                var dbPassword = _manager.GetAll().Where(x => x.Username == username).Select(x => x.Password).FirstOrDefault();
                if (temp == dbPassword)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _log.ErrorLog(ex.Message);
                return false;
            }
        }
    }
}
