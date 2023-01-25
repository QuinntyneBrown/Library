using Library.Core.Models.Artifacts;

namespace Library.Core
{
    public interface ICsProjFileManager
    {
        void AddUserSecretsId(string csprojFilePath);
        void AddNugetConfiguration(ProjectModel model);
        void ConvertToFramework48(ProjectModel model);
    }
}