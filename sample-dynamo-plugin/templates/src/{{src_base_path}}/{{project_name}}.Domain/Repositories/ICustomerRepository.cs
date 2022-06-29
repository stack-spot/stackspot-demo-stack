namespace {{project_name}}.Domain.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<Customer> QueryAsync(string cpf);
    Task CreateAsync(Customer customer);
}
