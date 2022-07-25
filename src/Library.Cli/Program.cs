using CommandLine;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = BuildContainer().GetService<IMediator>();

            ProcessArgs(mediator, args);
        }

        private static Parser _createParser() => new (options =>
        {
            options.CaseSensitive = false;
            options.HelpWriter = Console.Out;
            options.IgnoreUnknownArguments = true;
        });

        public static ServiceProvider BuildContainer()
        {
            var services = new ServiceCollection();

            Dependencies.Configure(services);

            return services.BuildServiceProvider();
        }

        public static void ProcessArgs(IMediator mediator, string[] args)
        {
            if (args.Length == 0 || args[0].StartsWith("-"))
            {
                args = new string[1] { "default" }.Concat(args).ToArray();
            }

            var verbs = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(type => type.GetCustomAttributes(typeof(VerbAttribute), true).Length > 0)
                .ToArray();

            _createParser().ParseArguments(args, verbs)
                .WithParsed(
                  (dynamic request) => mediator.Send(request));
        }
    }

}
