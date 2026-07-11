using System.Text.Json.Serialization;

namespace Api.Configuracoes;

public static class ConfiguracaoController
{
    public static IServiceCollection ConfigureController(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer().AddControllers().AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            opt.JsonSerializerOptions.IncludeFields = true;
            opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

        services.ConfigureHttpJsonOptions(opt =>
        {
            opt.SerializerOptions.PropertyNameCaseInsensitive = true;
            opt.SerializerOptions.IncludeFields = true;
            opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

        return services;
    }
}