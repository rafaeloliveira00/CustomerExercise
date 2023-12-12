using Connectlime.Application.Common.Interfaces;
using Connectlime.Domain.Entities;
using Connectlime.Domain.Events;

namespace Connectlime.Application.Persons.Commands.CreatePerson;

public record CreatePersonCommand : IRequest<int>
{
    public string? Name { get; init; }

    public string? Email { get; init; }

    public string? Nif { get; init; }
}

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        Person person = new()
        {
            Name = request.Name,
            Email = request.Email,
            Nif = request.Nif
        };

        _context.Persons.Add(person);

        person.AddDomainEvent(new PersonCreatedEvent(person));

        await _context.SaveChangesAsync(cancellationToken);

        return person.Id;
    }
}
