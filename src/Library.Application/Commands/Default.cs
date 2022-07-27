using CommandLine;
using Library.Core.Factories;
using Library.Core.Generators;
using Library.Core.Models;
using Library.Core.Options;
using MediatR;
using Microsoft.Extensions.Logging;
using Nelibur.ObjectMapper;

namespace Library.Application
{
    public class Default
    {
        [Verb("default")]
        public class Request : IRequest<Unit> {
            [Option('n',"name")]
            public string Name { get; set; } = string.Empty;

            [Option('r', "recipe")]
            public string Receipe { get; set; } = "library";
            
            [Option('l', "recipe-list")]
            public bool RecipeList { get; set; }

            [Option('d',"directory")]
            public string Directory { get; set; } = Environment.CurrentDirectory;
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly ILogger _logger;
            private readonly ISolutionGenerator _libraryGenerator;
            private readonly Dictionary<string, Func<CreateSolutionOptions, SolutionModel>> _recipeDictionary = new()
            {
                { "libray", SolutionModelFactory.CreateLibrary },
                { "webapi", SolutionModelFactory.CreateWebApi },
                { "minimal-api", SolutionModelFactory.CreateMinimalApi },
                { "microservice", SolutionModelFactory.CreateMicroservice },
                { "function", SolutionModelFactory.CreateFunction }
            };

            public Handler(ILogger logger, ISolutionGenerator libraryGenerator)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                _libraryGenerator = libraryGenerator?? throw new ArgumentNullException(nameof(libraryGenerator));
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"{nameof(Default)}: Handled");

                if(request.RecipeList)
                {
                    Console.WriteLine("Recipe List");

                    foreach(var item in _recipeDictionary)
                    {
                        Console.WriteLine(item.Key);
                    }

                    return new();
                }

                var options = TinyMapper.Map<CreateSolutionOptions>(request);

                var model = _recipeDictionary[request.Receipe](options);

                _libraryGenerator.Generate(model);

                return new();
            }
        }
    }
}
