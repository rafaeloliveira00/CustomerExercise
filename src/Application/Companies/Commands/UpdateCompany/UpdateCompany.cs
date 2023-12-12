using Connectlime.Application.Common.Interfaces;
using Connectlime.Domain.Entities;

namespace Connectlime.Application.Companies.Commands.UpdateCompany;

public record UpdateCompanyCommand : IRequest
{
    public int Id { get; init; }

    public string? Email { get; init; }
}

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCompanyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        Company? entity = await _context.Companies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        if (!string.IsNullOrEmpty(request.Email))
        {
            entity.Email = request.Email;
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
