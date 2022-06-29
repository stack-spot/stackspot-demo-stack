namespace {{project_name}}.Application.LoadCustomer;

public class LoadCustomerCommand : IRequest<LoadCustomerResult>
{
    public string Cpf { get; set; } = default!;
}