using Connectlime.Application.Common.Interfaces;
using Connectlime.Domain.Entities;

namespace Connectlime.Application.Transactions.Commands;

public record CreateTransactionCommand : IRequest<int>
{
    public string? ProductId { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }
    public decimal CompanyTax { get; init; }
    public decimal PersonTax { get; init; }
    public int CompanyId { get; init; }
    public int PersonId { get; init; }
}

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTransactionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        Transaction transaction = new()
        {
            ProductId = request.ProductId,
            UnitPrice = request.UnitPrice,
            Quantity = request.Quantity,
            CompanyTax = request.CompanyTax,
            PersonTax = request.PersonTax,
            CompanyId = request.CompanyId,
            PersonId = request.PersonId
        };

        _context.Transactions.Add(transaction);

        await _context.SaveChangesAsync(cancellationToken);

        return transaction.Id;
    }
}
