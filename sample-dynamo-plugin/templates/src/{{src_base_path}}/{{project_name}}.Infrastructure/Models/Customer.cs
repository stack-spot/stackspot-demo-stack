using Amazon.DynamoDBv2.DataModel;

namespace {{project_name}}.Infrastructure; 

[DynamoDBTable("{{global_inputs.table_name}}")]
public class Customer
{
    //Chave de Partição 
    [DynamoDBHashKey("id")]
    public string? Id { get; set; }

    [DynamoDBProperty("name")]
    public string? Name { get; set; }
}