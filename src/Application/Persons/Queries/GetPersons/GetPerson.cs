using Connectlime.Application.Common.Interfaces;

namespace Connectlime.Application.Persons.Queries.GetPersons;

public record GetPersonQuery : IRequest<PersonDto?>
{
    public int Id { get; set; }
}

public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPersonQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PersonDto?> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        return await _context.Persons
            .Where(x => x.Id == request.Id)
            .ProjectTo<PersonDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }
}
