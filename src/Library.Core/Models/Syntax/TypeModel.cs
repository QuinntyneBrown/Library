namespace Library.Core.Models.Syntax;

public class TypeModel
{
    public TypeModel(string? name = null)
    {
        Name = name;
        GenericTypeParameters = new List<TypeModel>();
    }

    public static TypeModel TaskOf(string typeName)
    {
        return new TypeModel("Task")
        {
            GenericTypeParameters = new List<TypeModel>()
        {
            new TypeModel(typeName)
        }
        };
    }

    public string Name { get; set; }
    public List<TypeModel> GenericTypeParameters { get; set; }
    public bool Nullable { get; set; }
    public bool Interface { get; set; }
}