using Library.Core;
using Library.Core.Models.Artifacts.Services;
using Library.Core.Models.Artifacts.Strategies.File.Generation;
using Library.Core.Models.Artifacts.Strategies.Project.Generation;
using Library.Core.Models.Artifacts.Strategies.Solution.Generation;

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
        services.AddSingleton<ISolutionGenerationStrategyFactory, SolutionGenerationStrategyFactory>();
        services.AddSingleton<ISolutionGenerationStrategy, SolutionGenerationStrategy>();
        services.AddSingleton<ICsProjFileManager, CsProjFileManager>();
        services.AddSingleton<IFileGenerationStrategyFactory, FileGenerationStrategyFactory>();
        services.AddSingleton<ISolutionService, SolutionService>();
        services.AddSingleton<IProjectGenerationStrategyFactory, ProjectGenerationStrategyFactory>();
        return services;
    }
}
