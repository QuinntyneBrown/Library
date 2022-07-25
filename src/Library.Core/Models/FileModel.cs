namespace Library.Core
{
    public class FileModel
    {
        public string Template { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string Namespace { get; init; } = string.Empty;
        public string Directory { get; init; } = string.Empty;
        public string Extension { get; init; } = string.Empty;
        public string Path => $"{Directory}{System.IO.Path.DirectorySeparatorChar}{Name}.{Extension}";
        public Dictionary<string, object>? Tokens { get; init; } = null;

        public FileModel(string template, string name, string extension, string directory, Dictionary<string, object>? tokens  = null)
        {
            Template = template;
            Name = name;
            Extension = extension;
            Directory = directory;
            Tokens = tokens;
        }

    }
}
