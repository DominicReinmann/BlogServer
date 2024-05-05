using BlogServer.CrossCutting.Logger;
using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Database;
using System.Diagnostics.CodeAnalysis;

namespace BlogServer.Logic.Manager.ConfigurationManagement
{
    public class ConfigManager : IConfigManager
    {
        private readonly DbManager<Configuration> _configManager;
        private readonly ILog _log;

        public ConfigManager(DbConntent context, ILog log)
        {
            _configManager = new DbManager<Configuration>(context);
            _log = log;
        }

        public IQueryable<Configuration> GetAll()
        {
            try
            {
                return _configManager.GetAll();

            }
            catch (Exception ex)
            {

                _log.ErrorLog($"Error getting Configuration {ex.InnerException.Message}");
                return null;
            }
        }
        public T? GetConfiguration<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string section, string key, T type)
        {
            var result = _configManager.GetAll().Where(x => x.Section == section && x.Key == key);
            if (result == null || !result.Any() || result.Count() > 1)
            {
                _log.ErrorLog("Beim Laden aus der " + section + " Config " + key + " ist ein Fehler aufgetreten.");
                throw new NullReferenceException("Beim Laden aus der " + section + " Config " + key + " ist ein Fehler aufgetreten.");
            }
            else
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(result.First().Value))
                    {
                        return (T)Convert.ChangeType(type, typeof(T));
                    }
                    return (T)Convert.ChangeType(result.First().Value, typeof(T));
                }
                catch (Exception ex)
                {
                    return (T)Convert.ChangeType(type, typeof(T));
                }
            }
        }
    }
}
