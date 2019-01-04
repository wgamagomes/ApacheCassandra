using System.Configuration;

namespace ApacheCassandra.Infra.Data.Utils
{
    public static class DbHelper
    {
        public static string GetAppSettings(this string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
