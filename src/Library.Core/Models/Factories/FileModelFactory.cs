namespace Library.Core.Models.Factories
{

    public static class FileModelFactory
    {
        public static TemplateFileModel CreateTemplate(string template, string name, string directory, string extension, Dictionary<string, object> tokens = null)
            => new TemplateFileModel(template, name, extension, directory, tokens);
    }
}
