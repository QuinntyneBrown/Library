// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Syntax;

public class ClassModel : InterfaceModel
{
    public ClassModel(string name)
        : base(name)
    {
        Fields = new List<FieldModel>();
        Constructors = new List<ConstructorModel>();
        Attributes = new List<AttributeModel>();
        AccessModifier = AccessModifier.Public;
    }

    public AccessModifier AccessModifier { get; set; }
    public List<FieldModel> Fields { get; set; }
    public List<ConstructorModel> Constructors { get; set; }
    public List<AttributeModel> Attributes { get; set; }
    public bool Static { get; set; }

    public void AddMethod(MethodModel method)
    {
        Methods.Add(method);
    }

    public ClassModel CreateDto()
        => new ClassModel($"{Name}Dto")
        {
            Properties = Properties
        };
}

