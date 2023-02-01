// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Artifacts;


public class TemplateFileModel : FileModel
{
    public string Template { get; init; } = string.Empty;
    public Dictionary<string, object>? Tokens { get; init; } = null;

    public TemplateFileModel(string template, string name, string extension, string directory, Dictionary<string, object>? tokens = null)
        : base(name, extension, directory)
    {
        Template = template;
        Tokens = tokens;
    }
}

