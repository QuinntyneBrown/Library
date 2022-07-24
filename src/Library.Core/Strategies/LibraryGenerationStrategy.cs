using Library.Core.Options;
using Microsoft.Extensions.Logging;

namespace Library.Core.Strategies
{
    public class LibraryGenerationStrategy : ILibraryGenerationStrategy
    {
        private readonly ICommandService _commandService;
        private readonly IFileSystem _fileSystem;
        private readonly ILogger _logger;

        public LibraryGenerationStrategy(ICommandService commandService, ILogger logger, IFileSystem fileSystem)
        {
            _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        }

        public int Order => 0;

        public bool CanHandle(CreateLibraryOptions options) => true;

        public void Create(CreateLibraryOptions options)
        {
            _logger.LogInformation($"{nameof(LibraryGenerationStrategy)}: Creating new solution name {options.Name} in {options.Directory}");

            var solutionDirectory = $"{options.Directory}{Path.DirectorySeparatorChar}{options.Name}";

            _fileSystem.CreateDirectory(solutionDirectory);

            _commandService.Start("dotnet new sln", solutionDirectory);

            _commandService.Start($"dotnet new xunit -n {options.Name}.UnitTests", solutionDirectory);

            _commandService.Start($"dotnet new classlib -n {options.Name}", solutionDirectory);

            _commandService.Start($"dotnet sln add {solutionDirectory}{Path.DirectorySeparatorChar}{options.Name}{Path.DirectorySeparatorChar}{options.Name}.csproj", solutionDirectory);

            _commandService.Start($"dotnet sln add {solutionDirectory}{Path.DirectorySeparatorChar}{options.Name}.UnitTests{Path.DirectorySeparatorChar}{options.Name}.UnitTests.csproj", solutionDirectory);

            _commandService.Start($"dotnet add {solutionDirectory}{Path.DirectorySeparatorChar}{options.Name}.UnitTests reference {solutionDirectory}{Path.DirectorySeparatorChar}{options.Name}{Path.DirectorySeparatorChar}{options.Name}.csproj");

            _commandService.Start($"start {options.Name}.sln", solutionDirectory);
        }
    }
}
