// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Syntax
{
    public class AggregateRootModel: TypeDeclarationModel
    {
        public string Namespace { get; set; }
        
        public List<EntityModel> Entities { get; private set; } = new List<EntityModel>();


        public string IdPropertyName { get; set; }
        public string IdPropertyType { get; set; }

        public AggregateRootModel(string name, List<PropertyModel> classProperties)
            :base(name)
        {
            Properties = classProperties;
        }

        public AggregateRootModel(string name, bool useIntIdPropertyType, bool useShortIdProperty, string properties)
            : base(name)
        {
            IdPropertyType = useIntIdPropertyType ? "int" : "Guid";

            IdPropertyName = useShortIdProperty ? "Id" : $"{((SyntaxToken)name).PascalCase}Id";

            Properties.Add(new PropertyModel(this, AccessModifier.Public, new TypeModel(IdPropertyType), IdPropertyName, PropertyAccessorModel.GetPrivateSet, key: true));

            if (!string.IsNullOrWhiteSpace(properties))
            {
                foreach (var property in properties.Split(','))
                {
                    var nameValuePair = property.Split(':');

                    Properties.Add(new PropertyModel(this, AccessModifier.Public, new TypeModel(nameValuePair.ElementAt(1)), nameValuePair.ElementAt(0), PropertyAccessorModel.GetPrivateSet));
                }
            }
        }

        public AggregateRootModel(string name)
            : base(name)
        {

        }

        public AggregateRootModel()
            :base(null)
        {

        }
    }
}

