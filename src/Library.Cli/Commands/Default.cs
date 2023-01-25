using CommandLine;
using Library.Core.Models;
using Library.Core.Models.Factories;
using Library.Core.Models.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using Nelibur.ObjectMapper;

namespace Library.Core;


[Verb("default")]
public class DefaultRequest : IRequest<Unit> {
    [Option('n',"name")]
    public string Name { get; set; } = string.Empty;

    [Option('p', "preset")]
    public string Preset { get; set; } = "library";
        
    [Option('l', "preset-list")]
    public bool PresetList { get; set; }

    [Option('d',"directory")]
    public string Directory { get; set; } = Environment.CurrentDirectory;
}

public class DefaultRequestHandler : IRequestHandler<DefaultRequest, Unit>
{
    private readonly ILogger<DefaultRequestHandler> _logger;
    private readonly ISolutionService _solutionService;
    private readonly Dictionary<string, Func<SolutionReferenceModel, SolutionModel>> _recipeDictionary = new()
    {
        { "library", SolutionModelFactory.CreateLibrary },
        { "webapi", SolutionModelFactory.CreateWebApi },
        { "minimal-api", SolutionModelFactory.CreateMinimalApi },
        { "microservice", SolutionModelFactory.CreateMicroservice },
        { "function", SolutionModelFactory.CreateFunction }
    };

    public DefaultRequestHandler(ILogger<DefaultRequestHandler> logger, ISolutionService libraryGenerator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _solutionService = libraryGenerator?? throw new ArgumentNullException(nameof(libraryGenerator));
    }

    public async Task<Unit> Handle(DefaultRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(DefaultRequestHandler)}: Handled");

        if(request.PresetList)
        {
            _logger.LogInformation("Recipe List");

            foreach(var item in _recipeDictionary)
            {
                _logger.LogInformation(item.Key);
            }

            return new();
        }

        var referenceModel = TinyMapper.Map<SolutionReferenceModel>(request);

        var model = _recipeDictionary[request.Preset](referenceModel);

        _solutionService.Create(model);

        return new();
    }
}
