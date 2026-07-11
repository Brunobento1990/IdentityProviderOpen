namespace Api.Configuracoes;

public static class ConfiguracaoSwagger
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddOpenApi();
        
        return services;
    }
}