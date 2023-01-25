using CommandLine;
using Library.Core.Models;
using Library.Core.Models.Factories;
using Library.Core.Models.Strategies.Solution.Update;
using MediatR;
using Microsoft.Extensions.Logging;
using Nelibur.ObjectMapper;

namespace Library.Cli.Commands;


public class AddProject
{
    [Verb("add-project")]
    public class Request : IRequest<Unit> {

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

    public class Handler : IRequestHandler<Request, Unit>
    {
        private readonly ILogger _logger;
        private readonly ISolutionUpdateStrategyFactory _projectUpdateStrategyFactory;

        public Handler(ILogger logger, ISolutionUpdateStrategyFactory projectUpdateStrategyFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _projectUpdateStrategyFactory = projectUpdateStrategyFactory ?? throw new ArgumentNullException(nameof(projectUpdateStrategyFactory));
        }

        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handled: {nameof(AddProject)}");

            var options = TinyMapper.Map<ProjectReferenceModel>(request);

            var previousSolutionModel = SolutionModelFactory.ReHydrate(options.ReferenceDirectory);

            var nextSolutionModel = SolutionModelFactory.ReHydrate(options.ReferenceDirectory);

            var projectModel = request.ProjectType switch
            {
                "webapi" => ProjectModelFactory.CreateWebApi(options.Name, previousSolutionModel.Directory),
                "xunit" => ProjectModelFactory.CreateXUnit(options.Name, previousSolutionModel.Directory),
                _ => ProjectModelFactory.CreateLibrary(options.Name, previousSolutionModel.Directory)
            };

            nextSolutionModel.AddProject(projectModel,options.DependsOns.Split(',').ToList(),options.Supplies.Split(',').ToList());

            _projectUpdateStrategyFactory.UpdateFor(previousSolutionModel, nextSolutionModel);   
            
            return new();
        }
    }
}
