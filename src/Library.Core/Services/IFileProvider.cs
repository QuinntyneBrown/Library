namespace Library.Core
{
    public interface IFileProvider
    {
        string Get(string searchPattern, string directory, int depth = 0);
    }
}
