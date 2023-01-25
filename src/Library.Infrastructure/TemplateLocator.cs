using Library.Core;
using Microsoft.Extensions.Logging;
using System.Net.NetworkInformation;
using System.Reflection;

namespace Library.Infrastructure;


public class TemplateLocator : ITemplateLocator
{
    private readonly ILogger<TemplateLocator> _logger;


    public TemplateLocator(ILogger<TemplateLocator> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));    
    }

    public string[] Get(string name)
    {
        foreach (Assembly _assembly in AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().FullName.Contains(nameof(Library.Infrastructure))).Distinct())
        {
            var resourceNames = _assembly.GetManifestResourceNames();

            var resourceName = getresourceName(resourceNames);

            if (!string.IsNullOrEmpty(resourceName))
            {
                return GetResource(_assembly, resourceName);
            }
        }

        string getresourceName(string[] resourceNames)
        {
            return resourceNames.SingleOrDefault(x => x.EndsWith(name)) == null ?
                resourceNames.Single(x => x.EndsWith($".{name}.txt")) : resourceNames.Single(x => x.EndsWith(name));
        }

        _logger.LogCritical("Name not found {0}", name);

        throw new Exception("Not Found");
    }

    public string[] GetResource(Assembly assembly, string name)
    {
        var lines = new List<string>();

        using (var stream = assembly.GetManifestResourceStream(name))
        {
            using (var streamReader = new StreamReader(stream!))
            {
                string line;
                while ((line = streamReader.ReadLine()!) != null)
                {
                    lines.Add(line);
                }
            }

            return lines.ToArray();
        }
    }
}
