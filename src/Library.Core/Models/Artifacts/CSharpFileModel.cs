// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Artifacts;

public class CSharpFileModel : FileModel
{
    public CSharpFileModel(string @namespace, string name, CSharpFileType cSharpFileType, string directory)
        : base(name, "cs", directory)
    {
        Namespace = @namespace;
        CSharpFileType = cSharpFileType;
    }


    public CSharpFileType CSharpFileType { get; set; } = CSharpFileType.Implementation;
    public string Namespace { get; set; } = string.Empty;
}

