namespace Library.Core.Models.Strategies.File.Generation
{
    public interface IFileGenerationStrategyFactory
    {
        void CreateFor<T>(T model)
            where T : FileModel;
    }
}
