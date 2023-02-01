// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Artifacts;

public class FileModel
{
    public string Name { get; init; } = string.Empty;
    public string Directory { get; init; } = string.Empty;
    public string Extension { get; init; } = string.Empty;
    public string Path => $"{Directory}{System.IO.Path.DirectorySeparatorChar}{Name}.{Extension}";

    public FileModel(string name, string extension, string directory)
    {
        Name = name;
        Extension = extension;
        Directory = directory;
    }
}

