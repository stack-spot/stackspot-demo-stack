using {{project_name}}.Application.LoadCustomer;
using {{project_name}}.Application.CreateCustomer;

namespace {{project_name}}.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CustomerController> _logger;
    public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{cpf}")]
    [ProducesResponseType(typeof(LoadCustomerResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> Get([FromRoute] String cpf)
    {
        try 
        {
            var result = await _mediator.Send(new LoadCustomerCommand{ Cpf = cpf} );
            if(string.IsNullOrEmpty(result?.Id))
                return NoContent();
            else
                return Ok(result);
        }
        catch(Exception ex) {
            throw new StackSpot.ErrorHandler.HttpResponseException(HttpStatusCode.InternalServerError, ex.Message, ex, true);
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch(Exception ex) 
        {
            throw new StackSpot.ErrorHandler.HttpResponseException(HttpStatusCode.InternalServerError, ex.Message, ex, true);
        }
    }    
}