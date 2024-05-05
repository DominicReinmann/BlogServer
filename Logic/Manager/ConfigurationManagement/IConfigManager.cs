using BlogServer.CrossCutting.Models.Domain;
using System.Diagnostics.CodeAnalysis;

namespace BlogServer.Logic.Manager.ConfigurationManagement
{
    public interface IConfigManager
    {
        IQueryable<Configuration> GetAll();
        T? GetConfigurationValue<[DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] T>(string section, string key, T type);
    }
}