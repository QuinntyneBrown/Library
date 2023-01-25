using CommandLine;
using Library.Core.Models.Artifacts;
using Library.Core.Models.Artifacts.Factories;
using Library.Core.Models.Artifacts.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using Nelibur.ObjectMapper;


namespace Library.Cli.Commands;


[Verb("default")]
public class SolutionCreateRequest : IRequest<Unit> {
    [Option('n', "name")]
    public string Name { get; set; } = string.Empty;

    [Option('p', "preset")]
    public string Preset { get; set; } = "library";

    [Option('d', "directory")]
    public string Directory { get; set; } = Environment.CurrentDirectory;
}

public class SolutionCreateRequestHandler : IRequestHandler<SolutionCreateRequest, Unit>
{
    private readonly ILogger<SolutionCreateRequestHandler> _logger;
    private readonly ISolutionService _solutionService;
    private readonly ISolutionModelFactory _solutionModelFactory;

    public SolutionCreateRequestHandler(
        ILogger<SolutionCreateRequestHandler> logger, 
        ISolutionService solutionService,
        ISolutionModelFactory solutionModelFactory
        )
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _solutionService = solutionService ?? throw new ArgumentNullException(nameof(solutionService));
        _solutionModelFactory = solutionModelFactory ?? throw new ArgumentNullException(nameof(solutionModelFactory));
    }

    public async Task<Unit> Handle(SolutionCreateRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handled: {0}", nameof(SolutionCreateRequestHandler));

        var referenceModel = TinyMapper.Map<SolutionReferenceModel>(request);

        var model = request.Preset switch
        {
            "library" => _solutionModelFactory.CreateLibrary(referenceModel),
            "webapi" => _solutionModelFactory.CreateWebApi(referenceModel),
            _ => throw new NotImplementedException(request.Preset)
        };

        _solutionService.Create(model);

        return new();
    }
}