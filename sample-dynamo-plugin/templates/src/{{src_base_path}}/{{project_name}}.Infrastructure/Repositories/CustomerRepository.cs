using Amazon.DynamoDBv2.DocumentModel;
using {{project_name}}.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using StackSpot.Database.DynamoDB;
using StackSpot.Database.DynamoDB.Common;

namespace {{project_name}}.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private IDynamoDB _dynamoDB;
    ILogger<CustomerRepository> _logger;
    public CustomerRepository(IDynamoDB dynamoDB, ILogger<CustomerRepository> logger)
    {
        _dynamoDB = dynamoDB;
        _logger = logger;
    }

    public async Task CreateAsync(Domain.Customer customer)
    {
        try 
        {
             await _dynamoDB.SaveAsync(new Infrastructure.Customer() { Id = customer.Id, Name = customer.Name});
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public async Task<Domain.Customer> QueryAsync(string cpf)
    {
        var queryFilter = new QueryFilter();
        queryFilter.AddCondition("id", QueryOperator.Equal, cpf);

        try {
            var queryResult = await _dynamoDB.QueryAsync<Customer>(new QueryConfig(queryFilter));
            var xpto = queryResult.FirstOrDefault();
              return new Domain.Customer(xpto?.Id, xpto?.Name);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
