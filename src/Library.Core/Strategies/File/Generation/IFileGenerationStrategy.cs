namespace Library.Core
{
    public interface IFileGenerationStrategy
    {
        void Create(dynamic model);

        int Order { get; }
        bool CanHandle(dynamic model);

    }
}
