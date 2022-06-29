
namespace {{project_name}}.Application.CreateCustomer;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerValidator()
    {
        RuleFor(command => command.Cpf)
        .NotNull()
        .NotEmpty();

        RuleFor(command => command.Cidade)
        .NotNull()
        .NotEmpty();
    }
}