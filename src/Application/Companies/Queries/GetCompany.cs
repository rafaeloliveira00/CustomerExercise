using Connectlime.Application.Common.Interfaces;

namespace Connectlime.Application.Companies.Queries;
public record GetCompanyQuery : IRequest<CompanyDto?>
{
    public int Id { get; set; }
}

public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCompanyQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CompanyDto?> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        return await _context.Companies
           .Where(x => x.Id == request.Id)
           .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
           .FirstOrDefaultAsync();
    }
}
