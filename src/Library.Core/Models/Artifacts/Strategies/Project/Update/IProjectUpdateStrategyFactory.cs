namespace Library.Core.Models.Artifacts.Strategies.Project.Update;

public interface IProjectUpdateStrategyFactory
{
    void UpdateFor(ProjectModel previousModel, ProjectModel newModel);
}
