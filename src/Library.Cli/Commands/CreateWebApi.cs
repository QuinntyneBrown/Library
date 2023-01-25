using CommandLine;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Library.Cli.Commands;

public class CreateWebApi
{
    [Verb("create-web-api")]
    public class Request : IRequest<Unit> {
        [Option('n',"name")]
        public string Name { get; set; } = string.Empty;

        [Option('r', "resources")]
        public string Resources { get; set; } = string.Empty;

        [Option('p', "properties")]
        public string Properties { get; set; } = string.Empty;

        [Option('d', "directory")]
        public string Directory { get; set; } = string.Empty;
    }

    public class Handler : IRequestHandler<Request, Unit>
    {
        private readonly ILogger _logger;

        public Handler(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handled: {nameof(CreateWebApi)}");

            return new();
        }
    }
}
