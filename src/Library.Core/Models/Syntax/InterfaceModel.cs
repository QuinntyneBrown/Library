// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Syntax;

public class InterfaceModel
{
    public string Name { get; set; }
    public List<MethodModel> Methods { get; set; }
    public List<PropertyModel> Properties { get; set; }
    public InterfaceModel(string name)
    {
        Name = name;
        Methods = new List<MethodModel>();
        Properties = new List<PropertyModel>();
    }
}
