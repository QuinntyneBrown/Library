// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Artifacts.Factories
{
    public static class ProjectModelFactory
    {
        public static ProjectModel CreateLibrary(string name, string parentDirectory, List<string>? additionalMetadata = null)
        {
            var project = new ProjectModel(name, parentDirectory);

            if (additionalMetadata != null)
                project.Metadata.Concat(additionalMetadata);

            project.Metadata.Add(Constants.Metadata.NugetPackage);

            return project;
        }

        public static ProjectModel CreateWebApi(string name, string parentDirectory, List<string>? additionalMetadata = null)
        {
            var project = new ProjectModel(name, parentDirectory, DotNetProjectType.WebApi, 0);

            project.Metadata.Add(Constants.Metadata.Api);

            if (additionalMetadata != null)
                project.Metadata.Concat(additionalMetadata);

            project.Packages = ResolvePackages(project);

            return project;
        }

        public static ProjectModel CreateWebApiFramework(string name, string parentDirectory, List<string>? additionalMetadata = null)
        {
            var project = new ProjectModel(name, parentDirectory, DotNetProjectType.WebApi, 0);

            project.Metadata.Add(Constants.Metadata.Api);

            if (additionalMetadata != null)
                project.Metadata.Concat(additionalMetadata);

            project.Packages = ResolvePackages(project);

            return project;
        }

        public static ProjectModel CreateXUnit(string name, string parentDirectory, List<string>? additionalMetadata = null)
        {
            var project = new ProjectModel(name, parentDirectory, DotNetProjectType.XUnit, 1);

            project.Metadata.Add(Constants.Metadata.Testing);

            if (additionalMetadata != null)
                project.Metadata.Concat(additionalMetadata);

            project.Packages = ResolvePackages(project);

            return project;
        }

        private static List<PackageModel> ResolvePackages(ProjectModel model)
        {
            if (model.Metadata.Contains(Constants.Metadata.Core))
            {
                return new List<PackageModel>
                {
                    new PackageModel("MediatR","10.0.1"),
                    new PackageModel("FluentValidation","10.3.6"),
                    new PackageModel("Newtonsoft.Json","13.0.1"),
                    new PackageModel("Microsoft.EntityFrameworkCore","6.0.2")
                };
            }

            if (model.Metadata.Contains(Constants.Metadata.Infrastructure))
            {
                return new List<PackageModel>
                {

                };
            }

            if (model.Metadata.Contains(Constants.Metadata.Api) && model.Framework == Constants.Framework.NetCore)
            {
                return new List<PackageModel>
                {
                    new PackageModel("Serilog.AspNetCore","5.0.0"),
                    new PackageModel("Serilog.Sinks.Seq","5.1.1"),
                    new PackageModel("SerilogTimings","2.3.0"),
                    new PackageModel("Microsoft.EntityFrameworkCore.InMemory","6.0.0"),
                    new PackageModel("Microsoft.AspNetCore.Mvc.NewtonsoftJson","6.0.2"),
                    new PackageModel("MediatR.Extensions.Microsoft.DependencyInjection","10.0.1")
                };
            }

            if (model.Metadata.Contains(Constants.Metadata.Api) && model.Framework == Constants.Framework.NetFramework48)
            {
                return new List<PackageModel>
                {

                };
            }

            if (model.Metadata.Contains(Constants.Metadata.UnitTests))
            {
                return new List<PackageModel>
                {

                };
            }

            if (model.Metadata.Contains(Constants.Metadata.IntegrationTest))
            {
                return new List<PackageModel>
                {

                };
            }

            if (model.Metadata.Contains(Constants.Metadata.Testing))
            {
                return new List<PackageModel>
                {
                    new PackageModel() {
                        Name = "Moq",
                    }
                };
            }

            throw new NotImplementedException();
        }
    }
}

