// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Syntax;

public class PropertyModel
{
    public PropertyModel(TypeDeclarationModel parent, AccessModifier accessModifier, TypeModel type, string name, List<PropertyAccessorModel> accessors, bool required = true, bool key = false)
    {
        AccessModifier = accessModifier;
        Type = type;
        Accessors = accessors;
        Name = name;
        Required = required;
        Id = key;
        Parent = parent;
        Interface = parent is InterfaceModel;
    }

    public AccessModifier AccessModifier { get; private set; }
    public TypeModel Type { get; private set; }
    public List<PropertyAccessorModel> Accessors { get; private set; } = new();
    public string Name { get; private set; }
    public bool Required { get; private set; }
    public bool Id { get; private set; }
    public bool Interface { get; set; }
    public TypeDeclarationModel Parent { get; set; }


}

