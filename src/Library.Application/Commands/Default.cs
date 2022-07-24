using CommandLine;
using Library.Core.Generators;
using Library.Core.Options;
using Library.Core.Strategies;
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
            [Option('d',"directory")]
            public string Directory { get; set; } = Environment.CurrentDirectory;
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly ILogger _logger;
            private readonly ILibraryGenerationStrategyFactory _factory;

            public Handler(ILogger logger, ILibraryGenerationStrategyFactory factory)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"{nameof(Default)}: Handled");

                var options = TinyMapper.Map<CreateLibraryOptions>(request);

                LibraryGenerator.Generate(options, _factory);

                return new();
            }
        }
    }
}
