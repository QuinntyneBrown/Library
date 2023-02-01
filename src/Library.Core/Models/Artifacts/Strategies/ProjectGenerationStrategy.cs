// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Library.Core.Models.Artifacts.Strategies.Abstractions;
using Microsoft.Extensions.Logging;

namespace Library.Core.Models.Artifacts.Strategies;

public class ProjectGenerationStrategy : ArtifactGenerationStrategyBase<ProjectModel>
{
    private readonly ICommandService _commandService;
    private readonly IFileSystem _fileSystem;
    private readonly ILogger<ProjectGenerationStrategy> _logger;

    private readonly ICsProjFileManager _csProjFileManager;

    public ProjectGenerationStrategy(
        IServiceProvider serviceProvider, 
        ICommandService commandService, 
        ILogger<ProjectGenerationStrategy> logger, 
        IFileSystem fileSystem,         
        ICsProjFileManager csProjFileManager)
        : base(serviceProvider)
    {
        _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
        _csProjFileManager = csProjFileManager ?? throw new ArgumentNullException(nameof(csProjFileManager));
    }

    public override void Create(IArtifactGenerationStrategyFactory artifactGenerationStrategyFactory, ProjectModel model, dynamic context = null)
    {
        var cmd = $"dotnet new {model.ProjectType} -n {model.Name}";

        _commandService.Start(cmd, model.ParentDirectory);

        if (model.Metadata.Contains(Constants.Metadata.NugetPackage))
        {
            _csProjFileManager.AddNugetConfiguration(model);
        }

        foreach (var package in model.Packages)
        {
            _commandService.Start($"dotnet add package {package.Name}", model.Directory);
        }

        foreach (var path in Directory.GetFiles(model.Directory, "*.cs", SearchOption.AllDirectories).Where(x => !x.EndsWith("Program.cs")))
        {
            _fileSystem.Delete(path);
        }
    }
}

