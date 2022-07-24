using Library.Core.Options;

namespace Library.Core.Strategies
{
    public interface ILibraryGenerationStrategy
    {
        int Order { get; }
        bool CanHandle(CreateLibraryOptions options);

        void Create(CreateLibraryOptions options);
    }
}
