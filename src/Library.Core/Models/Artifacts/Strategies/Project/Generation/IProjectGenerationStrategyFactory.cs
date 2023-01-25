namespace Library.Core.Models.Artifacts.Strategies.Project.Generation;

public interface IProjectGenerationStrategyFactory
{
    void CreateFor(ProjectModel model);
}
