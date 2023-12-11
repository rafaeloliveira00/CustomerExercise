using Connectlime.Application.Common.Interfaces;
using Connectlime.Application.Common.Mappings;
using Connectlime.Application.Common.Models;

namespace Connectlime.Application.Persons.Queries.GetPersons;

public record GetPersonsWithPaginationQuery : IRequest<PaginatedList<PersonDto>>
{
    public int? PageNumber { get; init; } = 1;
    public int? PageSize { get; init; } = 10;
}

public class GetPersonsWithPaginationQueryHandler : IRequestHandler<GetPersonsWithPaginationQuery, PaginatedList<PersonDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPersonsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<PersonDto>> Handle(GetPersonsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Persons
            .OrderBy(x => x.Name)
            .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber ?? 1, request.PageSize ?? 10);
    }
}
