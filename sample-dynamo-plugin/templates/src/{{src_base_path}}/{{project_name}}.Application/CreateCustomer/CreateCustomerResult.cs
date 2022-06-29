using {{project_name}}.Application.Common.Mappings;
using {{project_name}}.Domain;

namespace {{project_name}}.Application.CreateCustomer;

public class CreateCustomerResult : IMapFrom<Customer>
{
    public string? Cpf { get; set; }
    public string? Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Customer, CreateCustomerResult>()
            .ForMember(d => d.Cpf, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
    }

    
}