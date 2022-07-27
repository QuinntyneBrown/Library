using Library.Core.Models;

namespace Library.Core.Generators
{
    public interface ISolutionGenerator
    {
        void Generate(SolutionModel model);
    }
}
