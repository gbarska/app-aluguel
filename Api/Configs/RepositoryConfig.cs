using Infraestrutura;
using Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configs
{
    public static class RepositoryConfig
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(x=>x.UseMySql(configuration.GetConnectionString("DefaultConnection"),providerOptions => providerOptions.EnableRetryOnFailure()),ServiceLifetime.Scoped);         
        }
    }
}
