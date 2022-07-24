using Library.Core.Options;
using Library.Core.Strategies;

namespace Library.Core.Generators
{
    public class LibraryGenerator
    {
        public static void Generate(CreateLibraryOptions options, ILibraryGenerationStrategyFactory factory)
        {
            factory.CreateFor(options);
        }
    }
}
