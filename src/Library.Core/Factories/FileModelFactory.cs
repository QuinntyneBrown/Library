namespace Library.Core
{

    public static class FileModelFactory
    {
        public static FileModel Create(string template, string name, string directory, string extension, Dictionary<string,object> tokens = null)
            => new FileModel(template, name, extension, directory,tokens);
    }
}
