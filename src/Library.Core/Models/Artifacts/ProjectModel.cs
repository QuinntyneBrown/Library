using static System.IO.Path;

namespace Library.Core.Models.Artifacts;

public class ProjectModel
{
    public ProjectModel(string name, string parentDirectory, DotNetProjectType dotNetProjectType = DotNetProjectType.ClassLib, int order = 0)
    {
        ParentDirectory = parentDirectory;

        DotNetProjectType = dotNetProjectType;

        Name = name;

        Directory = $"{parentDirectory}{DirectorySeparatorChar}{name}";

        Order = order;
    }

    public string Framework { get; set; } = Constants.Framework.NetCore;
    public string Name { get; set; } = string.Empty;
    public string Path => $"{Directory}{DirectorySeparatorChar}{Name}.csproj";
    public DotNetProjectType DotNetProjectType { get; set; } = DotNetProjectType.ClassLib;
    public int Order { get; init; } = 0;
    public List<TemplateFileModel> Files { get; private set; } = new List<TemplateFileModel>();
    public string ParentDirectory { get; set; }
    public string Directory { get; set; }
    public List<PackageModel> Packages { get; set; } = new();
    public List<string> Metadata { get; set; } = new();
    public string ProjectType => DotNetProjectType switch
    {
        DotNetProjectType.XUnit => "xunit",
        DotNetProjectType.WebApi => "webapi",
        _ => "classlib"
    };
}
