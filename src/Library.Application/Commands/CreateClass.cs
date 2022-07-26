using CommandLine;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace Library.Application.Commands
{
    internal class CreateClass
    {
        [Verb("create-class")]
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
                _logger.LogInformation($"Handled: {nameof(CreateClass)}");

                return new();
            }
        }
    }
}