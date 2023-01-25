namespace Library.Core.Models.Artifacts.Factories
{

    public static class FileModelFactory
    {
        public static TemplateFileModel CreateTemplate(string template, string name, string directory, string extension, Dictionary<string, object> tokens = null)
            => new TemplateFileModel(template, name, extension, directory, tokens);
    }
}
