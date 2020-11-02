using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infraestrutura;
using Api.Configs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;

namespace Api.Utils
{
    public class Startup
    {
        IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            RepositoryConfig.Configure(services, Configuration);
            ServicesConfig.Configure(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,  IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandler>();
            app.UseRouting();
            
            app.UseCors(x=> x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints( endpoints =>
             { 
                 endpoints.MapControllers(); 
                 endpoints.MapFallbackToController("Index","Fallback");
            });
            
            ConfigureSwagger(app);
        }


        private static void ConfigureSwagger(IApplicationBuilder app)
        {
           // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "App Aluguel");
            });
        }

    }
}
