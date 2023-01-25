using System.Text.Json;
using Library.Core.Models.Syntax;

namespace Library.Core.Models.Artifacts.Factories
{
    public static class SolutionModelFactory
    {
        public static SolutionModel CreateWebApi(WebApiProjectReferenceModel options)
        {
            var solutionModel = CreateWebApi(new SolutionReferenceModel { Name = options.Name, ReferenceDirectory = options.Directory });

            solutionModel.Domain = new List<AggregateRootModel>();

            foreach (var resource in options.Resources.Split(','))
            {
                solutionModel.Domain.Add(new AggregateRootModel(resource));
            }

            for (var i = 0; i < solutionModel.Domain.Count; i++)
            {
                var aggregate = solutionModel.Domain.ElementAt(i);

                var properties = options.Properties.Split('|').ElementAt(i);

                foreach (var property in properties.Split(','))
                {
                    var propertyName = property.Split(':').ElementAt(0);

                    var propertyType = property.Split(':').ElementAt(1);

                    aggregate.Properties.Add(new PropertyModel("public", propertyType, propertyName, PropertyAccessorModel.GetSet));
                }
            }

            return solutionModel;
        }

        public static SolutionModel CreateLibrary(SolutionReferenceModel options)
        {
            var model = new SolutionModel(options.Name, options.ReferenceDirectory);

            var implementation = ProjectModelFactory.CreateLibrary(options.Name, $"{model.SrcDirectory}");

            var unitTests = ProjectModelFactory.CreateXUnit($"{options.Name}.UnitTests", $"{model.TestDirectory}");

            model.Projects.Add(implementation);

            model.Projects.Add(unitTests);

            model.DependOns.Add(new DependsOnModel(unitTests.Name, implementation.Name));

            var tokens = new TokensBuilder()
                .With("name", (Token)options.Name)
                .Build();

            model.Files.Add(FileModelFactory.CreateTemplate(Constants.Templates.ReadMe, "README", model.Directory, "md", tokens));

            return model;
        }

        public static SolutionModel CreateWebApi(SolutionReferenceModel options)
        {
            var model = new SolutionModel(options.Name, options.ReferenceDirectory);

            var core = ProjectModelFactory.CreateLibrary($"{options.Name}.Core", $"{model.SrcDirectory}");

            var infrastructure = ProjectModelFactory.CreateLibrary($"{options.Name}.Infrastructure", $"{model.SrcDirectory}");

            var api = ProjectModelFactory.CreateWebApi($"{options.Name}.Api", $"{model.SrcDirectory}");

            var testing = ProjectModelFactory.CreateLibrary($"{options.Name}.Testing", $"{model.TestDirectory}");

            var unitTests = ProjectModelFactory.CreateXUnit($"{options.Name}.UnitTests", $"{model.TestDirectory}");

            var integrationTests = ProjectModelFactory.CreateXUnit($"{options.Name}.IntegrationTests", $"{model.TestDirectory}");

            model.Projects.Add(api);

            model.Projects.Add(infrastructure);

            model.Projects.Add(core);

            model.Projects.Add(testing);

            model.Projects.Add(unitTests);

            model.Projects.Add(integrationTests);

            model.DependOns.Add(new DependsOnModel(api.Name, infrastructure.Name));

            model.DependOns.Add(new DependsOnModel(infrastructure.Name, core.Name));

            model.DependOns.Add(new DependsOnModel(unitTests.Name, testing.Name));

            model.DependOns.Add(new DependsOnModel(integrationTests.Name, testing.Name));

            model.DependOns.Add(new DependsOnModel(testing.Name, api.Name));

            var tokens = new TokensBuilder()
                .With("name", (Token)options.Name)
                .Build();

            model.Files.Add(FileModelFactory.CreateTemplate(Constants.Templates.ReadMe, "README", model.Directory, "md", tokens));

            return model;
        }

        public static SolutionModel CreateMinimalApi(SolutionReferenceModel options)
        {
            var model = new SolutionModel(options.Name, options.ReferenceDirectory);

            return model;
        }

        public static SolutionModel CreateFunction(SolutionReferenceModel options)
        {
            var model = new SolutionModel(options.Name, options.ReferenceDirectory);

            return model;
        }

        public static SolutionModel CreateMicroservice(SolutionReferenceModel options)
        {
            var model = new SolutionModel(options.Name, options.ReferenceDirectory);

            return model;
        }


        public static SolutionModel ReHydrate(string path)
        {
            var json = File.ReadAllText($"{path}{Path.DirectorySeparatorChar}solution.json");

            var model = JsonSerializer.Deserialize<SolutionModel>(json);

            return model!;
        }
    }
}
