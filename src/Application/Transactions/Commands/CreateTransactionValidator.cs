using Connectlime.Application.Common.Interfaces;

namespace Connectlime.Application.Transactions.Commands;

public class CreateTransactionValidator : AbstractValidator<CreateTransactionCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateTransactionValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.CompanyId)
            .NotEmpty().MustAsync(CompanyExists)
                .WithMessage("'CompanyId' not found.")
                .WithErrorCode("Not found");

        RuleFor(v => v.PersonId)
            .NotEmpty()
            .MustAsync(PersonExists)
                .WithMessage("'PersonId' not found.")
                .WithErrorCode("Not found");
    }

    public async Task<bool> CompanyExists(int id, CancellationToken cancellationToken)
    {
        return await _context.Companies
            .Where(c => c.Id == id)
            .AnyAsync();
    }

    public async Task<bool> PersonExists(int id, CancellationToken cancellationToken)
    {
        return await _context.Persons
            .Where(c => c.Id == id)
            .AnyAsync();
    }
}
