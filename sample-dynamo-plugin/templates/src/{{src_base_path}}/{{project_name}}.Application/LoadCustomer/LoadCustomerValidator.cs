namespace {{project_name}}.Application.LoadCustomer;

public class LoadCustomerValidator : AbstractValidator<LoadCustomerCommand>
{
    public LoadCustomerValidator()
    {
        RuleFor(command => command.Cpf)
        .NotNull()
        .NotEmpty();
    }
}