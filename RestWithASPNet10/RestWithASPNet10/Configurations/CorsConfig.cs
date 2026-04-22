namespace RestWithASPNet10.Configurations
{
    public static class CorsConfig
    {
        private static string[] GetAllowedOrigins(IConfiguration configuration)
        {
            return configuration.GetSection("Cors:Origins").Get<String[]>() ?? Array.Empty<string>();
        }

        public static void AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var origins = GetAllowedOrigins(configuration); // Busca valores do appsettings.json

            services.AddCors(options =>
            {
                // Exemplos de políticas de CORS hardCoded
                options.AddPolicy("LocalPolicy",
                    policy =>
                        policy.WithOrigins("http://localhost:3000")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                );

                options.AddPolicy("MultipleOriginPolicy",
                    policy =>
                        policy.WithOrigins(
                            "http://localhost:3000",
                            "http://localhost:8080"
                            )
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                );
                // Política de CORS a partir do appsettings.json
                options.AddPolicy("DefaultPolicy",
                    policy =>
                        policy.WithOrigins(origins)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                );
            });
        }

        // Força validação de CORS em ambiente de testes, como o Postman
        public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app, IConfiguration configuration)
        {
            var origins = GetAllowedOrigins(configuration);

            app.Use(async (context, next) =>
            {
                var origin = context.Request.Headers["Origin"].ToString();
                if (!string.IsNullOrEmpty(origin) &&
                    !origins.Contains(origin, StringComparer.OrdinalIgnoreCase))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden; // Forbidden
                    await context.Response.WriteAsync("CORS origin not allowed.");
                    return;
                }
                await next();
            });

            app.UseCors("DefaultPolicy"); // Aplicando política de CORS globalmente sem precisar adicionar manualmente nas classes de controller
            return app;
        }
    }
}
