using Connectlime.Domain.Entities;

namespace Connectlime.Application.Companies.Queries;

public class CompanyDto
{
    public string? Name { get; init; }
    public string? Email { get; set; }
    public string? Nipc { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Company, CompanyDto>();
        }
    }
}
