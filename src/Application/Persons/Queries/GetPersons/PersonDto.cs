using Connectlime.Domain.Entities;

namespace Connectlime.Application.Persons.Queries.GetPersons;

public class PersonDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? Email { get; set; }
    public string? Nif { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Person, PersonDto>();
        }
    }
}
