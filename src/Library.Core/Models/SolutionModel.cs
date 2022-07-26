﻿namespace Library.Core.Models
{
    public class SolutionModel
    {
        public SolutionModel()
        {

        }

        public SolutionModel(string name, string directory, List<AggregateRootModel>? domain = null)
        {
            Name = name;
            ParentDirectory = directory;
            Domain = domain;
        }

        public List<AggregateRootModel>? Domain { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ParentDirectory { get; set; } = string.Empty;
        public string Directory => $"{ParentDirectory}{Path.DirectorySeparatorChar}{Name}";
        public string SrcDirectory => $"{Directory}{Path.DirectorySeparatorChar}src";
        public string TestDirectory => $"{Directory}{Path.DirectorySeparatorChar}test";
        public List<ProjectModel> Projects { get; set; } = new();
        public List<DependsOnModel> DependOns { get; set; } = new();
        public List<FileModel> Files { get; set; } = new();

        public void AddProject(ProjectModel model, List<string> DependsOns, List<string> Supplies)
        {
            Projects.Add(model);
        }
    }
}