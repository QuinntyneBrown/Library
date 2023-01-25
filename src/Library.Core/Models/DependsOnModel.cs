namespace Library.Core.Models;

public class DependsOnModel
{
    public string Client { get; init; }
    public string Service { get; init; }

    public DependsOnModel(string client, string supplier)
    {
        Client = client;
        Service = supplier;
    }
}
