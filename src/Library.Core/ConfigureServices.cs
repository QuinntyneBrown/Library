using Library.Core;
using Library.Core.Models.Artifacts.Factories;
using Library.Core.Models.Artifacts.Services;
using Library.Core.Models.Artifacts.Strategies;
using Library.Core.Models.Artifacts.Strategies.Abstractions;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<ICommandService, CommandService>();
        services.AddSingleton<IFileSystem, FileSystem>();
        services.AddSingleton<ITemplateProcessor, LiquidTemplateProcessor>();
        services.AddSingleton<INamingConventionConverter, NamingConventionConverter>();
        services.AddSingleton<ITenseConverter, TenseConverter>();
        services.AddSingleton<INamespaceProvider, NamespaceProvider>();
        services.AddSingleton<IFileProvider, FileProvider>();
        
        
        services.AddSingleton<ICsProjFileManager, CsProjFileManager>();
        services.AddSingleton<ISolutionService, SolutionService>();
        
        services.AddSingleton<IArtifactGenerationStrategyFactory, ArtifactGenerationStrategyFactory>();
        services.AddSingleton<IArtifactGenerationStrategy, SolutionGenerationStrategy>();
        services.AddSingleton<IArtifactGenerationStrategy, ProjectGenerationStrategy>();

        services.AddSingleton<ISolutionModelFactory, SolutionModelFactory>();

        return services;
    }
}
