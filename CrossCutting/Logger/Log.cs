using BlogServer.Logic.Manager.ConfigurationManagement;

namespace BlogServer.CrossCutting.Logger
{
    public class Log : ILog
    {
        private readonly IConfigManager _config;
        private string _logPath;
        private string _logFile;

        public Log(IConfigManager config)
        {
            _config = config;
            _logPath = _config.GetConfigurationValue("Logging", "LogPath", string.Empty);
            string currentDate = DateTime.Now.ToString("yyy.MM.dd");
            _logFile = $"{currentDate}.log";
            CreateDirecotryIfNotExists();
        }

        private void CreateDirecotryIfNotExists()
        {
            try
            {
                if (!Directory.Exists(_logPath))
                {
                    Directory.CreateDirectory(_logPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DebugLog(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_logPath + _logFile, true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")} DEBUG: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ErrorLog(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_logPath + _logFile, true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")} DEBUG: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void InfoLog(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_logPath + _logFile, true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")} DEBUG: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WarningLog(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_logPath + _logFile, true))
                {
                    sw.WriteLine($"{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")} DEBUG: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
