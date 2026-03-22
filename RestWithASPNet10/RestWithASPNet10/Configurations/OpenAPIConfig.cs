using Microsoft.OpenApi;

namespace RestWithASPNet10.Configurations
{
    public static class OpenAPIConfig
    {
        private static readonly string AppName = "ASP.Net 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker and Kubertnetes";
        private static readonly string AppDescription = "This is a REST API developed in course 'APS.Net 2026 REST API's from 0 to Azure and GCP with .NET 10, Docker and Kubertnetes' from Udemy.";

        public static IServiceCollection AddOpenAPIConfig(this IServiceCollection services)
        {
            services.AddSingleton(new OpenApiInfo
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

            return services;
        }
    }
}
