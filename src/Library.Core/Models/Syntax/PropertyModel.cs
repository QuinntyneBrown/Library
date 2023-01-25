namespace Library.Core.Models.Syntax;

public class PropertyModel
{
    public string AccessModifier { get; private set; }
    public string Type { get; private set; }
    public List<PropertyAccessorModel> Accessors { get; private set; } = new();
    public string Name { get; private set; }
    public bool Required { get; private set; }
    public bool Key { get; private set; }

    public PropertyModel(string accessModifier, string type, string name, List<PropertyAccessorModel> accessors, bool required = true, bool key = false)
    {
        AccessModifier = accessModifier;
        Type = type;
        Accessors = accessors;
        Name = name;
        Required = required;
        Key = key;
    }
}
