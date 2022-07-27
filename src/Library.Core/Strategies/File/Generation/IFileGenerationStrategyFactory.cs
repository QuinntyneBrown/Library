namespace Library.Core.Strategies
{
    public interface IFileGenerationStrategyFactory
    {
        void CreateFor<T>(T model)
            where T : FileModel;
    }
}
