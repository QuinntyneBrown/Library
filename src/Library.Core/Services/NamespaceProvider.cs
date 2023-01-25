namespace Library.Core;

public class NamespaceProvider: INamespaceProvider
{
    public string Get(string directory, int depth = 0)
    {
        var parts = directory.Split(Path.DirectorySeparatorChar);

        if (parts.Length == depth)
            return "NamespaceNotFound";

        var projectFile = Directory.GetFiles(string.Join(Path.DirectorySeparatorChar, parts.Take(parts.Length - depth)), "*.csproj").FirstOrDefault();

        if(projectFile != null)
        {
            var rootNamespace = Path.GetFileNameWithoutExtension(projectFile);
            return depth > 0 
                ? $"{Path.GetFileNameWithoutExtension(projectFile)}.{string.Join(".", parts.Skip(parts.Length - depth))}" 
                : rootNamespace;                
        }

        return Get(directory, ++depth);
    }
}
