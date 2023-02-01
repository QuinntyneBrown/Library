// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Library.Core.Models.Artifacts.Strategies.Abstractions;
using Microsoft.Extensions.Logging;

namespace Library.Core.Models.Artifacts.Strategies;

public class CSharpFileGenerationStrategy : ArtifactGenerationStrategyBase<CSharpFileModel>
{
    private readonly IFileSystem _fileSystem;
    private readonly ITemplateLocator _templateLocator;
    private readonly ITemplateProcessor _templateProcessor;
    private readonly ILogger _logger;

    public CSharpFileGenerationStrategy(
        IServiceProvider serviceProvider,
        IFileSystem fileSystem,
        ITemplateLocator templateLocator,
        ITemplateProcessor templateProcessor,
        ILogger logger
        ) : base(serviceProvider)
    {
        _fileSystem = fileSystem ?? throw new ArgumentException(nameof(fileSystem));
        _templateProcessor = templateProcessor ?? throw new ArgumentNullException(nameof(templateProcessor));
        _templateLocator = templateLocator ?? throw new ArgumentNullException(nameof(templateLocator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public override void Create(IArtifactGenerationStrategyFactory artifactGenerationStrategyFactory, CSharpFileModel model, dynamic context = null)
    {
        throw new NotImplementedException();
    }
}

