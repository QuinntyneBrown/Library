namespace Library.Core.Models
{
    public class SolutionModel
    {
        public SolutionModel()
        {

        }

        public SolutionModel(string name, string directory)
        {
            Name = name;
            ParentDirectory = directory;
        }

        public string Name { get; set; } = string.Empty;
        public string ParentDirectory { get; set; } = string.Empty;
        public string Directory => $"{ParentDirectory}{Path.DirectorySeparatorChar}{Name}";
        public List<ProjectModel> Projects { get; set; } = new();
        public List<DependsOnModel> DependOns { get; set; } = new();
        public List<FileModel> Files { get; set; } = new();

        public void AddProject(ProjectModel model, List<string> DependsOns, List<string> Supplies)
        {
            Projects.Add(model);
        }
    }
}