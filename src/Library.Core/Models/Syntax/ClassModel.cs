namespace Library.Core.Models.Syntax;

public class ClassModel
{
    public List<PropertyModel> Properties { get; set; } = new List<PropertyModel>();

    public List<ConstructorModel> Constructors { get; set; } = new List<ConstructorModel>();

    public List<MethodModel> Methods { get; set; } = new List<MethodModel>();
}
