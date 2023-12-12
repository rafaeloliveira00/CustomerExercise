using Connectlime.Application.Common.Interfaces;
using Connectlime.Domain.Entities;

namespace Connectlime.Application.Companies.Commands.CreateCompany;
public record CreateCompanyCommand : IRequest<int>
{
    public string? Name { get; init; }

    public string? Email { get; init; }

    public string? Nipc { get; init; }
}

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCompanyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        Company company = new()
        {
            Name = request.Name,
            Email = request.Email,
            Nipc = request.Nipc
        };

        _context.Companies.Add(company);

        await _context.SaveChangesAsync(cancellationToken);

        return company.Id;
    }
}
