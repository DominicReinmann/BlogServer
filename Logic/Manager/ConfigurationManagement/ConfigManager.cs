using BlogServer.CrossCutting.Models.Domain;
using BlogServer.Logic.Database;
using System.Diagnostics.CodeAnalysis;

namespace BlogServer.Logic.Manager.ConfigurationManagement
{
    public class ConfigManager : IConfigManager
    {
        private readonly DbManager<Configuration> _configManager;

        public ConfigManager(DbConntent context)
        {
            _configManager = new DbManager<Configuration>(context);
        }

        public IQueryable<Configuration> GetAll()
        {
            try
            {
                return _configManager.GetAll();

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error getting Configuration {ex.InnerException.Message}");
                return null;
            }
        }
        public T? GetConfigurationValue<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string section, string key, T type)
        {
            var result = _configManager.GetAll().Where(x => x.Section == section && x.Key == key);
            if (result == null || !result.Any() || result.Count() > 1)
            {
                Console.WriteLine("Beim Laden aus der " + section + " Config " + key + " ist ein Fehler aufgetreten.");
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
