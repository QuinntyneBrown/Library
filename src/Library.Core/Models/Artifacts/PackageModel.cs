// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Artifacts;

public class PackageModel
{
    public string Name { get; init; }
    public string Version { get; init; }
    public bool IsPreRelease { get; init; }

    public PackageModel(string name, string verison)
    {
        Name = name;
        Version = verison;
    }

    public PackageModel()
    {

    }
}

