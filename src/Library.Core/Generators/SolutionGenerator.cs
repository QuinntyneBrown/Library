using Library.Core.Models;
using Library.Core.Strategies;

namespace Library.Core.Generators
{
    public class SolutionGenerator: ISolutionGenerator
    {
        private readonly ISolutionGenerationStrategyFactory _factory;

        public SolutionGenerator(ISolutionGenerationStrategyFactory factory)
        {
            _factory = factory;
        }

        public void Generate(SolutionModel model)
        {
            _factory.CreateFor(model);
        }
    }
}
