namespace Library.Core.Models.Syntax
{
    public class AggregateRootModel
    {
        public string Namespace { get; set; }
        public List<PropertyModel> Properties { get; private set; } = new List<PropertyModel>();

        public List<EntityModel> Entities { get; private set; } = new List<EntityModel>();

        public string Name { get; set; }

        public string IdPropertyName { get; set; }
        public string IdPropertyType { get; set; }

        public AggregateRootModel(string name, List<PropertyModel> classProperties)
        {
            Name = name;
            Properties = classProperties;
        }

        public AggregateRootModel(string name, bool useIntIdPropertyType, bool useShortIdProperty, string properties)
        {
            Name = name;

            IdPropertyType = useIntIdPropertyType ? "int" : "Guid";

            IdPropertyName = useShortIdProperty ? "Id" : $"{((Token)name).PascalCase}Id";

            Properties.Add(new PropertyModel("public", IdPropertyType, IdPropertyName, PropertyAccessorModel.GetPrivateSet, key: true));

            if (!string.IsNullOrWhiteSpace(properties))
            {
                foreach (var property in properties.Split(','))
                {
                    var nameValuePair = property.Split(':');

                    Properties.Add(new PropertyModel("public", nameValuePair.ElementAt(1), nameValuePair.ElementAt(0), PropertyAccessorModel.GetPrivateSet));
                }
            }
        }

        public AggregateRootModel(string name)
        {
            Name = name;
        }

        public AggregateRootModel()
        {

        }
    }
}
