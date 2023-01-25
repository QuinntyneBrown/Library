namespace Library.Core.Models.Artifacts;


public class TemplateFileModel : FileModel
{
    public string Template { get; init; } = string.Empty;
    public Dictionary<string, object>? Tokens { get; init; } = null;

    public TemplateFileModel(string template, string name, string extension, string directory, Dictionary<string, object>? tokens = null)
        : base(name, extension, directory)
    {
        Template = template;
        Tokens = tokens;
    }
}
