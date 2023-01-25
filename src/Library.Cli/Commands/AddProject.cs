using CommandLine;
using Library.Core.Models;
using Library.Core.Models.Factories;
using Library.Core.Models.Strategies.Solution.Update;
using MediatR;
using Microsoft.Extensions.Logging;
using Nelibur.ObjectMapper;

namespace Library.Cli.Commands;


[Verb("add-project")]
public class AddProjectRequest : IRequest<Unit> {

    [Value(0, Required = true)]
    public string Name { get; set; } = string.Empty;

    [Option('t',"project-type")]
    public string ProjectType { get; set; } = "classlib";

    [Option("depends-on")]
    public string DependsOns { get; set; } = string.Empty;

    [Option('s',"supplies")]
    public string Supplies { get; set; } = string.Empty;

    [Option('d',"directory")]
    public string Directory { get; set; } = Environment.CurrentDirectory;
}

public class AddProjectRequestHandler : IRequestHandler<AddProjectRequest, Unit>
{
    private readonly ILogger<AddProjectRequestHandler> _logger;
    private readonly ISolutionUpdateStrategyFactory _projectUpdateStrategyFactory;

    public AddProjectRequestHandler(
        ILogger<AddProjectRequestHandler> logger, 
        ISolutionUpdateStrategyFactory projectUpdateStrategyFactory)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _projectUpdateStrategyFactory = projectUpdateStrategyFactory ?? throw new ArgumentNullException(nameof(projectUpdateStrategyFactory));
    }

    public async Task<Unit> Handle(AddProjectRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Handled: {nameof(AddProjectRequestHandler)}");

        var projectReferenceModel = TinyMapper.Map<ProjectReferenceModel>(request);

        var previousSolutionModel = SolutionModelFactory.ReHydrate(projectReferenceModel.ReferenceDirectory);

        var nextSolutionModel = SolutionModelFactory.ReHydrate(projectReferenceModel.ReferenceDirectory);

        var projectModel = request.ProjectType switch
        {
            "webapi" => ProjectModelFactory.CreateWebApi(projectReferenceModel.Name, previousSolutionModel.Directory),
            "xunit" => ProjectModelFactory.CreateXUnit(projectReferenceModel.Name, previousSolutionModel.Directory),
            _ => ProjectModelFactory.CreateLibrary(projectReferenceModel.Name, previousSolutionModel.Directory)
        };

        nextSolutionModel.AddProject(projectModel,projectReferenceModel.DependsOns.Split(',').ToList(),projectReferenceModel.Supplies.Split(',').ToList());

        _projectUpdateStrategyFactory.UpdateFor(previousSolutionModel, nextSolutionModel);   
            
        return new();
    }
}
