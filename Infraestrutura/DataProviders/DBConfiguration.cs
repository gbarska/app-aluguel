using Microsoft.Extensions.Configuration;

namespace Infraestrutura.DataProviders
{
    public static class DBConfiguration
    {
        public static string GetConnection()
        {
            var config = new ConfigurationBuilder().Build();
            var connString = config.GetConnectionString("DefaultConnection");
            return connString;
        }
    }
}