using EvolveDb;
using Microsoft.Data.SqlClient;
using Serilog;

namespace RestWithASPNet10.Configurations
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolve(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                var connectionString = configuration["MSSQLServerConnection:MSSQLServerConnectionString"];

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string is not configured.");
                }

                try
                {
                    using var evolveConnection = new SqlConnection(connectionString);

                    var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
                    { 
                        Locations = new[] { "db/migrations", "db/dataset" },
                        IsEraseDisabled = true
                    };

                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    Log.Error("Database migration failed: {Message}", ex.Message);
                    throw;
                }
            }
            return services;
        }
    }
}
