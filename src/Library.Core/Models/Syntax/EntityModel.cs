namespace Library.Core.Models.Syntax;

public class EntityModel
{
    public string AggregateRootName { get; private set; }
    public List<PropertyModel> Properties { get; private set; } = new List<PropertyModel>();

    public string Name { get; set; }

    public EntityModel(string aggregateRootName, string name, List<PropertyModel> classProperties)
    {
        AggregateRootName = aggregateRootName;
        Name = name;
        Properties = classProperties;
    }

    public EntityModel(string name, List<PropertyModel> classProperties)
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
