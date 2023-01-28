using CommandLine;
using Library.Core;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Library.Cli.Commands;


[Verb("nuget-add-packages")]
internal class NugetPackagesAddRequest : IRequest<Unit> {
    [Option('f', "feed-directory")]
    public string FeedDirectory { get; set; } = @"C:\packages";

    [Option('d',"directory")]
    public string Directory { get; set; } = Environment.CurrentDirectory;
}

internal class NugetAddPackagesRequestHandler : IRequestHandler<NugetPackagesAddRequest, Unit>
{
    private readonly ILogger<NugetAddPackagesRequestHandler> _logger;
    private readonly ICommandService _commandService;
    private readonly IFileSystem _fileSystem;

    public NugetAddPackagesRequestHandler(ILogger<NugetAddPackagesRequestHandler> logger, ICommandService commandService, IFileSystem fileSystem)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public async Task<Unit> Handle(NugetPackagesAddRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handled: {0}", nameof(NugetAddPackagesRequestHandler));

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

