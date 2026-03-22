using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.OpenApi;

namespace RestWithASPNet10.Configurations
{
    public static class SwaggerConfig
    {
        private static readonly string AppName = "ASP.Net 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker and Kubertnetes";
        private static readonly string AppDescription = "This is a REST API developed in course 'APS.Net 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker and Kubertnetes' from Udemy.";

        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = AppName,
                    Version = "v1",
                    Description = AppDescription,
                    Contact = new OpenApiContact
                    {
                        Name = "Isaac Lima",
                        Email = "isaac.silva.css@gmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                options.CustomSchemaIds(type => type.FullName);
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerSpecification(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "swagger-ui";
                options.DocumentTitle = AppName;
            });
            return app;
        }
    }
}
