using Library.Core.Models;
using Library.Core.Models.Strategies.Solution.Generation;

namespace Library.Core.Models.Services
{
    public class SolutionService : ISolutionService
    {
        private readonly ISolutionGenerationStrategyFactory _factory;

        public SolutionService(ISolutionGenerationStrategyFactory factory)
        {
            _factory = factory;
        }

        public void Generate(SolutionModel model)
        {
            _factory.CreateFor(model);
        }
    }
}
