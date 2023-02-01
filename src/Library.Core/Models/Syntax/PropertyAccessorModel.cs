// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Syntax;

public class PropertyAccessorModel
{
    public string AccessModifier { get; private set; }
    public PropertyAccessorType Type { get; private set; }

    public PropertyAccessorModel(string accessModifier, PropertyAccessorType classPropertyAccessorType)
        : this(classPropertyAccessorType)
    {
        AccessModifier = accessModifier;
    }

    public PropertyAccessorModel(PropertyAccessorType classPropertyAccessorType)
    {
        Type = classPropertyAccessorType;
    }

    private PropertyAccessorModel()
    {

    }

    public static PropertyAccessorModel Get => new PropertyAccessorModel(PropertyAccessorType.Get);

    public static PropertyAccessorModel Set => new PropertyAccessorModel(PropertyAccessorType.Set);

    public static PropertyAccessorModel PrivateSet => new PropertyAccessorModel("private", PropertyAccessorType.Set);

    public static List<PropertyAccessorModel> GetPrivateSet => new List<PropertyAccessorModel>() { Get, PrivateSet };

    public static List<PropertyAccessorModel> GetSet => new List<PropertyAccessorModel>() { Get, Set };

}

