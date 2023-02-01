// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Artifacts;

public class ProjectReferenceModel
{
    public string Name { get; set; } = string.Empty;
    public string ProjectType { get; set; } = string.Empty;
    public string ReferenceDirectory { get; set; } = string.Empty;
    public string DependsOns { get; set; } = string.Empty;
    public string Supplies { get; set; } = string.Empty;

}

