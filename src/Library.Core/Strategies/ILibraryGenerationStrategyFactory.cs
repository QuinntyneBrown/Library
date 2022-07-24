using Library.Core.Options;

namespace Library.Core.Strategies
{
    public interface ILibraryGenerationStrategyFactory
    {
        void CreateFor(CreateLibraryOptions options);
    }
}
