using Library.Core;
using Library.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services){
        services.AddSingleton<ITemplateLocator, TemplateLocator>();
    }

}

