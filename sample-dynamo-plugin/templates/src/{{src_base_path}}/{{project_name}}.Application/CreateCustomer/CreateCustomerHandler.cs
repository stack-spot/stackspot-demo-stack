
using {{project_name}}.Domain.Interfaces.Repositories;

namespace {{project_name}}.Application.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
{
    private readonly ILogger<CreateCustomerHandler> _logger;
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;


    public CreateCustomerHandler(ILogger<CreateCustomerHandler> logger,
                                    IMapper mapper,
                                    ICustomerRepository customerRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Init Handle");
        CreateCustomerResult result = new CreateCustomerResult();
        try
        {
            var customer = new Domain.Customer(request.Cpf, request.Cidade);
            await _customerRepository.CreateAsync(customer);
            _logger.LogInformation("Customer Created.");
            result = _mapper.Map<CreateCustomerResult>(customer);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
        return result;
    }
}