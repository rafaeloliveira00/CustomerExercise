using Connectlime.Application.Persons.Queries.GetPersons;

namespace Connectlime.Application.Companies.Queries;

public class GetCompaniesWithPaginationValidator : AbstractValidator<GetPersonsWithPaginationQuery>
{
    public GetCompaniesWithPaginationValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
