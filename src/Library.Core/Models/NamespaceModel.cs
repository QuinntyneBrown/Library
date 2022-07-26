namespace Library.Core.Models
{
    public class NamespaceModel
    {
        public List<string> Usings { get; set; } = new();
        public string Name { get; set; } = string.Empty;
        public List<ClassModel> Classes { get; set; } = new();
    }
}
