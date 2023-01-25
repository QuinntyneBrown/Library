using CommandLine;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Library.Cli.Commands
{
    internal class CreateService
    {
        [Verb("create-service")]
        internal class Request : IRequest<Unit> {

        }

        internal class Handler : IRequestHandler<Request, Unit>
        {
            private readonly ILogger _logger;

            public Handler(ILogger logger)
            {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"Handled: {nameof(CreateService)}");

                return new();
            }
        }
    }
}
