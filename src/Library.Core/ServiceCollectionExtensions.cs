using Library.Core.Generators;
using Library.Core.Strategies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Library.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLibraryCodeGenerationServices(this IServiceCollection services, IConfiguration configuration, ILogger logger)
        {
            services.AddSingleton(configuration);
            services.AddSingleton<ICommandService, CommandService>();
            services.AddSingleton<IFileSystem, FileSystem>();
            services.AddSingleton<ITemplateLocator, TemplateLocator>();
            services.AddSingleton<ITemplateProcessor, LiquidTemplateProcessor>();
            services.AddSingleton<INamingConventionConverter, NamingConventionConverter>();
            services.AddSingleton<ITenseConverter, TenseConverter>();
            services.AddSingleton<INamespaceProvider, NamespaceProvider>();
            services.AddSingleton<IFileProvider, FileProvider>();
            services.AddSingleton<ISolutionGenerationStrategyFactory, SolutionGenerationStrategyFactory>();
            services.AddSingleton<ISolutionGenerationStrategy, SolutionGenerationStrategy>();
            services.AddSingleton<ICsProjFileManager, CsProjFileManager>();
            services.AddSingleton<IFileGenerationStrategyFactory, FileGenerationStrategyFactory>();
            services.AddSingleton<ISolutionGenerator, SolutionGenerator>();
            services.AddSingleton<IProjectGenerationStrategyFactory, ProjectGenerationStrategyFactory>();
            services.AddSingleton(logger);
            return services;
        }
    }
}
