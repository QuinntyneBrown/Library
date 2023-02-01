// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
