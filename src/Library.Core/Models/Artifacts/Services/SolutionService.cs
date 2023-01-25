using Library.Core.Models.Artifacts.Strategies.Solution.Generation;

namespace Library.Core.Models.Artifacts.Services
{
    public class SolutionService : ISolutionService
    {
        private readonly ISolutionGenerationStrategyFactory _factory;

        public SolutionService(ISolutionGenerationStrategyFactory factory)
        {
            _factory = factory;
        }

        public void Create(SolutionModel model)
        {
            _factory.CreateFor(model);
        }
    }
}
