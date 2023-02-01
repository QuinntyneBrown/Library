// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Library.Core.Models.Artifacts.Strategies.Abstractions;
using Microsoft.Extensions.Logging;

namespace Library.Core.Models.Artifacts.Strategies;

public class XUnitFileGenerationStrategy : ArtifactGenerationStrategyBase<XUnitFileModel>
{
    public XUnitFileGenerationStrategy(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override void Create(IArtifactGenerationStrategyFactory artifactGenerationStrategyFactory, XUnitFileModel model, dynamic context = null)
    {
        throw new NotImplementedException();
    }
}

