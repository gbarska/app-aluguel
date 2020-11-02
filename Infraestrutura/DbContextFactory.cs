
using Infraestrutura.DataProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infraestrutura.Data
 {
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            var connectionString = DBConfiguration.GetConnection();
            builder.UseMySql(connectionString);
            return new ApplicationContext(builder.Options);
        }
   }
 }
