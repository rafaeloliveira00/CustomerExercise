using Connectlime.Application.Common.Interfaces;

namespace Connectlime.Application.Companies.Commands.CreateCompany;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateCompanyCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Email)
            .NotEmpty()
            .MaximumLength(255)
            .EmailAddress();

        RuleFor(v => v.Nipc)
            .NotEmpty()
            .MaximumLength(9)
            .MustAsync(BeUniqueNipc)
                .WithMessage("'Nipc' must be unique.")
                .WithErrorCode("Unique");
    }

    public async Task<bool> BeUniqueNipc(string nipc, CancellationToken cancellationToken)
    {
        return await _context.Companies
            .AllAsync(l => l.Nipc != nipc, cancellationToken);
    }
}
