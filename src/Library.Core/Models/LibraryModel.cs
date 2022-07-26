namespace Library.Core.Models
{
    public class LibraryModel
    {
        public LibraryModel(string name, string directory)
        {
            Name = name;
            Directory = directory;
        }

        public string Name { get; set; } = string.Empty;
        public string Directory { get; set; } = string.Empty;
        public string SolutionDirectory => $"{Directory}{Path.DirectorySeparatorChar}{Name}";
        public List<ProjectModel> Projects { get; set; } = new();
        public List<DependsOnModel> DependOns { get; set; } = new();
        public List<TemplateFileModel> Files { get; set; } = new ();
    }
}
