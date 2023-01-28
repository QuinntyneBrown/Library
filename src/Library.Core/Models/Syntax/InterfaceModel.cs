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