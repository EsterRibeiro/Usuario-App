namespace UsuariosApp.API.Extensions;

/// <summary>
/// Classe de extensão para configuração de política de CORS
/// </summary>
public static class CorsConfigExtension
{
    //atributos
    private static string _policyName = "DefaultPolicy";
    private static string[] _origins = {
            "http://localhost:4200"
        };

    public static IServiceCollection AddCorsConfig(this IServiceCollection services)
    {
        services.AddCors(options => {
            options.AddPolicy(_policyName, policy => {
                policy.WithOrigins(_origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        return services;
    }

    public static IApplicationBuilder UseCorsConfig(this IApplicationBuilder app)
    {
        app.UseCors(_policyName);
        return app;
    }
}

