using Library.Core.Models;

namespace Library.Core.Factories
{
    public static class LibraryModelFactory
    {
        public static LibraryModel Create(string name, string directory)
        {
            var model = new LibraryModel(name, directory);

            var implementation = ProjectModelFactory.Create(name, $"{directory}{Path.DirectorySeparatorChar}{name}");

            var unitTests = ProjectModelFactory.CreateXUnit($"{name}.UnitTests", $"{directory}{Path.DirectorySeparatorChar}{name}");

            model.Projects.Add(implementation);

            model.Projects.Add(unitTests);

            model.DependOns.Add(new DependsOnModel(unitTests, implementation));

            return model;
        }
    }
}
