namespace Library.Core.Models
{

    public class AggregateRootCSharpFileModel: CSharpFileModel
    {
        public AggregateRootCSharpFileModel(string @namespace, AggregateRootModel model, string directory)
            :base(model.Namespace, model.Name, CSharpFileType.Implementation, directory)
        {

        }

        public AggregateRootModel AggregateRootModel { get; set; }
    }

    public class EntityModel
    {
        public string AggregateRootName { get; private set; }
        public List<ClassPropertyModel> Properties { get; private set; } = new List<ClassPropertyModel>();

        public string Name { get; set; }

        public EntityModel(string aggregateRootName, string name, List<ClassPropertyModel> classProperties)
        {
            AggregateRootName = aggregateRootName;
            Name = name;
            Properties = classProperties;
        }

        public EntityModel(string name, List<ClassPropertyModel> classProperties)
        {
            Name = name;
            Properties = classProperties;
        }

        public EntityModel(string name)
        {
            Name = name;
        }

        public EntityModel()
        {

        }
    }

    public class AggregateRootModel
    {
        public string Namespace { get; set; }
        public List<ClassPropertyModel> Properties { get; private set; } = new List<ClassPropertyModel>();

        public List<EntityModel> Entities { get; private set; } = new List<EntityModel>();

        public string Name { get; set; }

        public string IdPropertyName { get; set; }
        public string IdPropertyType { get; set; }

        public AggregateRootModel(string name, List<ClassPropertyModel> classProperties)
        {
            Name = name;
            Properties = classProperties;
        }

        public AggregateRootModel(string name, bool useIntIdPropertyType, bool useShortIdProperty, string properties)
        {
            Name = name;

            IdPropertyType = useIntIdPropertyType ? "int" : "Guid";

            IdPropertyName = useShortIdProperty ? "Id" : $"{((Token)name).PascalCase}Id";

            Properties.Add(new ClassPropertyModel("public", IdPropertyType, IdPropertyName, ClassPropertyAccessorModel.GetPrivateSet, key: true));

            if (!string.IsNullOrWhiteSpace(properties))
            {
                foreach (var property in properties.Split(','))
                {
                    var nameValuePair = property.Split(':');

                    Properties.Add(new ClassPropertyModel("public", nameValuePair.ElementAt(1), nameValuePair.ElementAt(0), ClassPropertyAccessorModel.GetPrivateSet));
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
    public class ClassModel
    {
        public List<ClassPropertyModel> Properties { get; set; } = new List<ClassPropertyModel>();

        public List<ConstructorModel> Constructors { get; set; } = new List<ConstructorModel>();

        public List<ClassMethodModel> Methods { get; set; } = new List<ClassMethodModel>();
    }

    public class ConstructorModel
    {
    }

    public class ClassMethodModel
    {
    }

    public class ClassPropertyModel
    {
        public string AccessModifier { get; private set; }
        public string Type { get; private set; }
        public List<ClassPropertyAccessorModel> Accessors { get; private set; } = new();
        public string Name { get; private set; }
        public bool Required { get; private set; }
        public bool Key { get; private set; }

        public ClassPropertyModel(string accessModifier, string type, string name, List<ClassPropertyAccessorModel> accessors, bool required = true, bool key = false)
        {
            AccessModifier = accessModifier;
            Type = type;
            Accessors = accessors;
            Name = name;
            Required = required;
            Key = key;
        }
    }

    public class ClassPropertyAccessorModel
    {
        public string AccessModifier { get; private set; }
        public ClassPropertyAccessorType Type { get; private set; }

        public ClassPropertyAccessorModel(string accessModifier, ClassPropertyAccessorType classPropertyAccessorType)
            : this(classPropertyAccessorType)
        {
            AccessModifier = accessModifier;
        }

        public ClassPropertyAccessorModel(ClassPropertyAccessorType classPropertyAccessorType)
        {
            Type = classPropertyAccessorType;
        }

        private ClassPropertyAccessorModel()
        {

        }

        public static ClassPropertyAccessorModel Get => new ClassPropertyAccessorModel(ClassPropertyAccessorType.Get);

        public static ClassPropertyAccessorModel Set => new ClassPropertyAccessorModel(ClassPropertyAccessorType.Set);

        public static ClassPropertyAccessorModel PrivateSet => new ClassPropertyAccessorModel("private", ClassPropertyAccessorType.Set);

        public static List<ClassPropertyAccessorModel> GetPrivateSet => new List<ClassPropertyAccessorModel>() { Get, PrivateSet };

        public static List<ClassPropertyAccessorModel> GetSet => new List<ClassPropertyAccessorModel>() { Get, Set };

    }

    public enum ClassPropertyAccessorType
    {
        Get,
        Set,
    }
}
