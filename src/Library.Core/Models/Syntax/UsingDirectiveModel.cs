namespace Library.Core.Models.Syntax;

public class UsingDirectiveModel
{
    public UsingDirectiveModel(string name)
    {
        Name = name;
    }
    public string Name { get; set; }
}