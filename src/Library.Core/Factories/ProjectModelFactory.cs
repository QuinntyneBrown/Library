using Library.Core.Models;

namespace Library.Core.Factories
{
    public static class ProjectModelFactory
    {
        public static ProjectModel Create(string name, string parentDirectory)
        {
            var project = new ProjectModel(name, parentDirectory);

            return project;
        }

        public static ProjectModel CreateXUnit(string name, string parentDirectory)
        {
            var project = new ProjectModel(name, parentDirectory, DotNetProjectType.XUnit, 1);

            project.Packages.Add(new PackageModel()
            {
                Name = "Moq",
            });

            return project;
        }
    }
}
