namespace {{project_name}}.Application.CreateCustomer;

public class CreateCustomerCommand : IRequest<CreateCustomerResult>
{
    public string Cpf { get; set; } = default!;
    public string Cidade { get; set; } = default!;
}