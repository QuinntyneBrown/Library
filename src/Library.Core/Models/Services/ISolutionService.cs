using Library.Core.Models;

namespace Library.Core.Models.Services;

public interface ISolutionService
{
    void Generate(SolutionModel model);
}
