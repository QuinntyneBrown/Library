namespace Library.Core.Models
{
    public class ProjectModel
    {
        public ProjectModel(string name, string parentDirectory, DotNetProjectType dotNetProjectType = DotNetProjectType.ClassLib, int order = 0)
        {
            ParentDirectory = parentDirectory;

            DotNetProjectType = dotNetProjectType;

            Name = name;

            Directory = $"{parentDirectory}{Path.DirectorySeparatorChar}{name}";

            Order = order;
        }

        public string Name { get; set; } = string.Empty;
        public DotNetProjectType DotNetProjectType { get; set; } = DotNetProjectType.ClassLib;
        public int Order { get; init; } = 0;
        public List<FileModel> Files { get; private set; } = new List<FileModel>();
        public string ParentDirectory { get; set; }
        public string Directory { get; set; }
        public List<PackageModel> Packages { get; private set; } = new();
        public string ProjectType => DotNetProjectType switch
        {
            DotNetProjectType.XUnit => "xunit",
            _ => "classlib"
        };
    }
}
