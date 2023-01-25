namespace Library.Core.Models.Artifacts.Strategies.File.Generation;

public interface IFileGenerationStrategyFactory
{
    void CreateFor<T>(T model)
        where T : FileModel;
}
