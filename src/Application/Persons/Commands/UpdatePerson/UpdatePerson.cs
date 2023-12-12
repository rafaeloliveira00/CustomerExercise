using Connectlime.Application.Common.Interfaces;
using Connectlime.Domain.Entities;

namespace Connectlime.Application.Persons.Commands.UpdatePerson;

public record UpdatePersonCommand : IRequest
{
    public int Id { get; init; }

    public string? Email { get; init; }
}

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdatePersonCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        Person? entity = await _context.Persons
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        if (!string.IsNullOrEmpty(request.Email))
        {
            entity.Email = request.Email;
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
