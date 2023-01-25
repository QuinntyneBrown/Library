namespace Library.Core.Models.Artifacts;

public class XUnitFileModel : FileModel
{
    public XUnitFileModel(string @namespace, string name, string sut, string directory)
        : base(name, "cs", directory)
    {
        Namespace = @namespace;
        Sut = sut;
    }

    public string Sut { get; set; }
    public string Namespace { get; set; } = string.Empty;

}
