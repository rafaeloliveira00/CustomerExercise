using Connectlime.Application.Common.Interfaces;
using Connectlime.Application.Common.Mappings;
using Connectlime.Application.Common.Models;

namespace Connectlime.Application.Companies.Queries;
public record GetCompaniesWithPaginationQuery : IRequest<PaginatedList<CompanyDto>>
{
    public int? PageNumber { get; init; } = 1;
    public int? PageSize { get; init; } = 10;
}

public class GetCompaniesWithPaginationQueryHandler : IRequestHandler<GetCompaniesWithPaginationQuery, PaginatedList<CompanyDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCompaniesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CompanyDto>> Handle(GetCompaniesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Companies
            .OrderBy(x => x.Name)
            .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber ?? 1, request.PageSize ?? 10);
    }
}
