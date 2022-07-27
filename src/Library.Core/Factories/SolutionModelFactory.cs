using Library.Core.Models;
using Library.Core.Options;
using System.Text.Json;

namespace Library.Core.Factories
{
    public static class SolutionModelFactory
    {
        public static SolutionModel CreateLibrary(CreateSolutionOptions options)
        {
            var model = new SolutionModel(options.Name, options.Directory);

            var implementation = ProjectModelFactory.CreateLibrary(options.Name, $"{options.Directory}{Path.DirectorySeparatorChar}{options.Name}");

            var unitTests = ProjectModelFactory.CreateXUnit($"{options.Name}.UnitTests", $"{options.Directory}{Path.DirectorySeparatorChar}{options.Name}");

            model.Projects.Add(implementation);

            model.Projects.Add(unitTests);

            model.DependOns.Add(new DependsOnModel(unitTests.Name, implementation.Name));

            var tokens = new TokensBuilder()
                .With("name", (Token)options.Name)
                .Build();

            model.Files.Add(FileModelFactory.CreateTemplate(Constants.Templates.ReadMe, "README", model.Directory, "md", tokens));

            return model;
        }

        public static SolutionModel CreateWebApi(CreateSolutionOptions options)
        {
            var model = new SolutionModel(options.Name, options.Directory);

            var core = ProjectModelFactory.CreateLibrary($"{options.Name}.Core", $"{options.Directory}{Path.DirectorySeparatorChar}{options.Name}");

            var infrastructure = ProjectModelFactory.CreateLibrary($"{options.Name}.Infrastructure", $"{options.Directory}{Path.DirectorySeparatorChar}{options.Name}");

            var api = ProjectModelFactory.CreateWebApi($"{options.Name}.Api", $"{options.Directory}{Path.DirectorySeparatorChar}{options.Name}");

            model.Projects.Add(api);

            model.Projects.Add(infrastructure);

            model.Projects.Add(core);

            model.DependOns.Add(new DependsOnModel(api.Name, infrastructure.Name));

            model.DependOns.Add(new DependsOnModel(infrastructure.Name, api.Name));

            var tokens = new TokensBuilder()
                .With("name", (Token)options.Name)
                .Build();

            model.Files.Add(FileModelFactory.CreateTemplate(Constants.Templates.ReadMe, "README", model.Directory, "md", tokens));

            return model;
        }

        public static SolutionModel CreateMinimalApi(CreateSolutionOptions options)
        {
            return null;
        }

        public static SolutionModel CreateFunction(CreateSolutionOptions options)
        {
            return null;
        }

        public static SolutionModel CreateMicroservice(CreateSolutionOptions options)
        {
            return null;
        }


        public static SolutionModel ReHydrate(string path)
        {
            var json = File.ReadAllText($"{path}{Path.DirectorySeparatorChar}solution.json");

            var model = JsonSerializer.Deserialize<SolutionModel>(json);

            return model!;
        }
    }
}
