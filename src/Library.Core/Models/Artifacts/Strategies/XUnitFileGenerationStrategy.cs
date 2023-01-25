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
