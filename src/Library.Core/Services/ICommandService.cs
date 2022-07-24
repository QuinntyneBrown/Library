namespace Library.Core
{
    public interface ICommandService
    {
        void Start(string command, string workingDirectory = null, bool waitForExit = true);
    }
}
