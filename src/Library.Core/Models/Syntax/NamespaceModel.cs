// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Syntax;

public class NamespaceModel
{
    public List<string> Usings { get; set; } = new();
    public string Name { get; set; } = string.Empty;
    public List<ClassModel> Classes { get; set; } = new();
}

