// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Artifacts;

public class DependsOnModel
{
    public string Client { get; init; }
    public string Service { get; init; }

    public DependsOnModel(string client, string supplier)
    {
        Client = client;
        Service = supplier;
    }
}

