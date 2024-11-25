namespace BankSystem;

public class Worker
{
    //create worker name position id permission
    public string Name { get; set; }
    public string Position { get; set; }
    public readonly int Id;
    public List<string> Permissions;

    public Worker(string name, string position, int id, List<string> permissions)
    {
        Name = name;
        Position = position;
        Id = id;
        Permissions = permissions;
    }

    public string WorkerDetails()
    {
        string pers = "";
        foreach (string permission in Permissions)
        {
            pers += permission + ", ";
        }

        return $"{Name} on position {Position} has id {Id} and permissions {pers}";
    }
}