using System.Text.Json;
using Library.Core.Models.Syntax;

namespace Library.Core.Models.Artifacts.Factories;
public class SolutionModelFactory: ISolutionModelFactory
{
    public SolutionModel CreateWebApi(WebApiProjectReferenceModel webApiProjectReferenceModel)
    {
        var solutionModel = CreateWebApi(new SolutionReferenceModel { Name = webApiProjectReferenceModel.Name, ReferenceDirectory = webApiProjectReferenceModel.Directory });

        solutionModel.Domain = new List<AggregateRootModel>();

        foreach (var resource in webApiProjectReferenceModel.Resources.Split(','))
        {
            solutionModel.Domain.Add(new AggregateRootModel(resource));
        }

        for (var i = 0; i < solutionModel.Domain.Count; i++)
        {
            var aggregate = solutionModel.Domain.ElementAt(i);

            var properties = webApiProjectReferenceModel.Properties.Split('|').ElementAt(i);

            foreach (var property in properties.Split(','))
            {
                var propertyName = property.Split(':').ElementAt(0);

                var propertyType = property.Split(':').ElementAt(1);

                aggregate.Properties.Add(new PropertyModel("public", propertyType, propertyName, PropertyAccessorModel.GetSet));
            }
        }

        return solutionModel;
    }

    public SolutionModel CreateLibrary(SolutionReferenceModel solutionReferenceModel)
    {
        var model = new SolutionModel(solutionReferenceModel.Name, solutionReferenceModel.ReferenceDirectory);

        var implementation = ProjectModelFactory.CreateLibrary(solutionReferenceModel.Name, $"{model.SrcDirectory}");

        var unitTests = ProjectModelFactory.CreateXUnit($"{solutionReferenceModel.Name}.UnitTests", $"{model.TestDirectory}");

        model.Projects.Add(implementation);

        model.Projects.Add(unitTests);

        model.DependOns.Add(new DependsOnModel(unitTests.Name, implementation.Name));

        var tokens = new TokensBuilder()
            .With("name", (Token)solutionReferenceModel.Name)
            .Build();

        model.Files.Add(FileModelFactory.CreateTemplate(Constants.Templates.ReadMe, "README", model.Directory, "md", tokens));

        return model;
    }

    public SolutionModel CreateWebApi(SolutionReferenceModel solutionReferenceModel)
    {
        var model = new SolutionModel(solutionReferenceModel.Name, solutionReferenceModel.ReferenceDirectory);

        var core = ProjectModelFactory.CreateLibrary($"{solutionReferenceModel.Name}.Core", $"{model.SrcDirectory}");

        var infrastructure = ProjectModelFactory.CreateLibrary($"{solutionReferenceModel.Name}.Infrastructure", $"{model.SrcDirectory}");

        var api = ProjectModelFactory.CreateWebApi($"{solutionReferenceModel.Name}.Api", $"{model.SrcDirectory}");

        var testing = ProjectModelFactory.CreateLibrary($"{solutionReferenceModel.Name}.Testing", $"{model.TestDirectory}");

        var unitTests = ProjectModelFactory.CreateXUnit($"{solutionReferenceModel.Name}.UnitTests", $"{model.TestDirectory}");

        var integrationTests = ProjectModelFactory.CreateXUnit($"{solutionReferenceModel.Name}.IntegrationTests", $"{model.TestDirectory}");

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
            .With("name", (Token)solutionReferenceModel.Name)
            .Build();

        model.Files.Add(FileModelFactory.CreateTemplate(Constants.Templates.ReadMe, "README", model.Directory, "md", tokens));

        return model;
    }

    public SolutionModel ReHydrate(string path)
    {
        var json = File.ReadAllText($"{path}{Path.DirectorySeparatorChar}solution.json");

        var model = JsonSerializer.Deserialize<SolutionModel>(json);

        return model!;
    }
}
