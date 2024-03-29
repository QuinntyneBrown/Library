// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Syntax;

public class TypeDeclarationModel
{
    public TypeDeclarationModel(string name)
    {
        Name = name;
        Properties = new List<PropertyModel>();
        UsingDirectives = new List<UsingDirectiveModel>();
    }

    public string Name { get; set; }
    public List<PropertyModel> Properties { get; set; }

    public List<UsingDirectiveModel> UsingDirectives { get; set; }
}
