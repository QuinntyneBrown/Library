namespace Library.Core.Models
{
    public class CSharpFileModel: FileModel
    {
        public CSharpFileModel(string @namespace, string name, CSharpFileType cSharpFileType, string directory)
            :base(name,"cs",directory)
        {
            Namespace = @namespace;
            CSharpFileType = cSharpFileType;
        }


        public CSharpFileType CSharpFileType { get; set; } = CSharpFileType.Implementation;
        public string Namespace { get; set; } = string.Empty;
    }
}
