using {{project_name}}.Application.Common.Mappings;
using {{project_name}}.Domain;

namespace {{project_name}}.Application.LoadCustomer;

public class LoadCustomerResult : IMapFrom<Customer>
{
    public string? Id { get; set; }
    public string? Name { get; set; }
}