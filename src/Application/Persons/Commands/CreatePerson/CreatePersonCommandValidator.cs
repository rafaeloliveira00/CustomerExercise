using Connectlime.Application.Common.Interfaces;

namespace Connectlime.Application.Persons.Commands.CreatePerson;

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    private readonly IApplicationDbContext _context;

    public CreatePersonCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Email)
            .NotEmpty()
            .MaximumLength(255)
            .EmailAddress();

        RuleFor(v => v.Nif)
            .NotEmpty()
            .MaximumLength(9)
            .MustAsync(BeUniqueNif)
                .WithMessage("'Nif' must be unique.")
                .WithErrorCode("Unique");
    }

    public async Task<bool> BeUniqueNif(string nif, CancellationToken cancellationToken)
    {
        return await _context.Persons
            .AllAsync(l => l.Nif != nif, cancellationToken);
    }
}
