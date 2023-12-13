using Connectlime.Application.Common.Interfaces;
using Connectlime.Application.Common.Mappings;
using Connectlime.Application.Common.Models;

namespace Connectlime.Application.Transactions.Queries;

public record GetTransactionWithPaginationQuery : IRequest<PaginatedList<TransactionDto>>
{
    public int? CompanyId { get; init; }
    public int? PersonId { get; init; }

    public int? PageNumber { get; init; } = 1;
    public int? PageSize { get; init; } = 10;
}

public class GetTransactionWithPaginationQueryHandler : IRequestHandler<GetTransactionWithPaginationQuery, PaginatedList<TransactionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTransactionWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TransactionDto>> Handle(GetTransactionWithPaginationQuery request, CancellationToken cancellationToken)
    {
        IQueryable<TransactionDto> query = _context.Transactions
            .ProjectTo<TransactionDto>(_mapper.ConfigurationProvider);

        if (request.CompanyId.HasValue)
        {
            query = query.Where(t => t.CompanyId == request.CompanyId.Value);
        }

        if (request.PersonId.HasValue)
        {
            query = query.Where(t => t.PersonId == request.PersonId.Value);
        }

        return await query.PaginatedListAsync(request.PageNumber ?? 1, request.PageSize ?? 10);
    }
}
