using Serilog;

namespace RestWithASPNet10.Configurations
{
    public static class LoggingConfig
    {
        public static void AddSeriLogLogging(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Debug()    
                .WriteTo.Console()
                .CreateLogger();

            builder.Host.UseSerilog();
        }   
    }
}
