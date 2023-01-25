namespace Library.Core.Models.Artifacts.Strategies.Project.Generation;

public interface IProjectGenerationStrategy
{
    int Order { get; }
    bool CanHandle(ProjectModel model);

    void Create(ProjectModel model);
}
