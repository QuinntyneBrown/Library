using CommandLine;
using Library.Core;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Library.Application.Commands
{
    internal class NugetAddPackages
    {
        [Verb("nuget-add-packages")]
        internal class Request : IRequest<Unit> {
            [Option('f', "feed-directory")]
            public string FeedDirectory { get; set; } = @"C:\packages";

            [Option('d',"directory")]
            public string Directory { get; set; } = Environment.CurrentDirectory;
        }

        internal class Handler : IRequestHandler<Request, Unit>
        {
            private readonly ILogger _logger;
            private readonly ICommandService _commandService;
            private readonly IFileSystem _fileSystem;

            public Handler(ILogger logger, ICommandService commandService, IFileSystem fileSystem)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
                _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"Handled: {nameof(NugetAddPackages)}");

                _logger.LogInformation($"Feed Directory: {request.FeedDirectory}");

                foreach(var directory in Directory.GetDirectories(request.Directory,"*", SearchOption.AllDirectories))
                {
                    if(Path.GetFileName(directory) != "node_modules")
                    {
                        foreach (var path in Directory.GetFiles(directory, "*.nupkg", SearchOption.AllDirectories))
                        {
                            _commandService.Start($"nuget add {path} -source {request.FeedDirectory}");
                        }
                    }
                }

                return new();
            }
        }
    }
}
