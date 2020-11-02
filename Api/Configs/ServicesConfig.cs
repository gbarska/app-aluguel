using System;
using Api.Utils;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Api.Configs
{
    public static class ServicesConfig
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers()
            .AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.NullValueHandling =  NullValueHandling.Ignore;
            });

            services.AddAutoMapper(typeof(MappingsProfiles));   
            services.AddCors();
            
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "App Aluguel",
                        Version = "v1",
                        Description = "Ih Aprendi master class- AspNet Core 3.0",
                        Contact = new OpenApiContact
                        {
                            Name = "gbarska",
                            Url = new Uri("https://github.com/gbarska")
                        }
                    });
            });
        }
    }
}