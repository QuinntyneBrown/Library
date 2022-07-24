namespace Library.Core
{
    public interface IFileFactory
    {
        FileModel Create(string template, string name, string directory, string extension);
    }
}
