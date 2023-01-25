using Library.Core;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddCliServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DefaultRequest));

        services.AddLogging();
    }

}
