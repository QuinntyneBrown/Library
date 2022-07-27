using Library.Application;
using Library.Core;
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
            services.AddMediatR(typeof(Default));

            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>(optional:true)
                .Build();

            var logger = CreateLoggerFactory().CreateLogger("library-cli");

            services.AddLibraryCodeGenerationServices(configuration, logger);

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
