namespace Library.Core.Models.Artifacts;

public class FileModel
{
    public string Name { get; init; } = string.Empty;
    public string Directory { get; init; } = string.Empty;
    public string Extension { get; init; } = string.Empty;
    public string Path => $"{Directory}{System.IO.Path.DirectorySeparatorChar}{Name}.{Extension}";

    public FileModel(string name, string extension, string directory)
    {
        Name = name;
        Extension = extension;
        Directory = directory;
    }
}
