using CNN.Core.Business;
using MediatR;
using System.Reflection;

namespace CNN.App.API.Configs;

public static class ConfigureServiceCollection
{
    public static IServiceCollection AddMediaRConfig(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.AsScoped();
        }, Assembly.GetAssembly(typeof(MediaREntryPoint))!);

        return services;
    }
}
