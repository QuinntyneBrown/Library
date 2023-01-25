using CommandLine;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Library.Cli.Commands
{
    internal class AddAggregate
    {
        [Verb("add-aggregate")]
        internal class AddAggregateRequest : IRequest<Unit> {
            [Option('n',"name")]
            public string Name { get; set; } = string.Empty;
            [Option('p', "properties")]
            public string Properties { get; set; } = string.Empty;
            [Option('d', "directory")]
            public string Directory { get; set; } = Environment.CurrentDirectory;
        }

        internal class AddAggregateRequestHandler : IRequestHandler<AddAggregateRequest, Unit>
        {
            private readonly ILogger _logger;

            public AddAggregateRequestHandler(ILogger logger)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            public async Task<Unit> Handle(AddAggregateRequest request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"Handled: {nameof(AddAggregate)}");

                return new();
            }
        }
    }
}
