namespace {{project_name}}.Domain;

public class Customer
{
    public Customer(string? id, string? name)
    {
        Id = id;
        Name = name;
    }
    public string? Id { get; private set; }
  
    public string? Name { get; private set; }
    
}