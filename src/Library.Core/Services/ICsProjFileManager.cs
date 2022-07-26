using Library.Core.Models;

namespace Library.Core
{
    public interface ICsProjFileManager
    {
        void AddUserSecretsId(string csprojFilePath);
        void AddNugetConfiguration(ProjectModel model);
    }
}