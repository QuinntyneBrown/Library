using Library.Core;
using Library.Core.Strategies;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Library.Cli
{
    public class Dependencies
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddMediatR(typeof(Library.Application.Default));

            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>(optional:true)
                .Build();

            services.AddSingleton<IConfiguration>(_ => configuration);

            services.AddSingleton<ICommandService, CommandService>();
            services.AddSingleton<IFileSystem, FileSystem>();
            services.AddSingleton<ITemplateLocator, TemplateLocator>();
            services.AddSingleton<ITemplateProcessor, LiquidTemplateProcessor>();
            services.AddSingleton<INamingConventionConverter, NamingConventionConverter>();
            services.AddSingleton<ITenseConverter, TenseConverter>();
            services.AddSingleton<INamespaceProvider, NamespaceProvider>();
            services.AddSingleton<IFileProvider, FileProvider>();
            services.AddSingleton<IFileGenerationStrategy,FileGenerationStrategy>();
            services.AddSingleton<ILibraryGenerationStrategyFactory, LibraryGenerationStrategyFactory>();
            services.AddSingleton<ILibraryGenerationStrategy, LibraryGenerationStrategy>();
            services.AddSingleton<ICsProjFileManager, CsProjFileManager>();
            services.AddSingleton(CreateLoggerFactory().CreateLogger("cli"));
            
        }

        private static ILoggerFactory CreateLoggerFactory()
        {
            return LoggerFactory.Create(builder =>
            {
                builder.AddProvider(new LoggerProvider(new LoggerOptions(true, ConsoleColor.Red, ConsoleColor.DarkYellow, Console.Out)));
            });
        }
    }
}
