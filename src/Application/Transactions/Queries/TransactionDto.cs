using System.ComponentModel.DataAnnotations.Schema;
using Connectlime.Domain.Entities;

namespace Connectlime.Application.Transactions.Queries;

public class TransactionDto
{
    public int CompanyId { get; init; }
    public int PersonId { get; init; }
    public string? ProductId { get; init; }
    public decimal UnitPrice { get; init; }
    public int Quantity { get; init; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal CompanyTax { get; init; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal PersonTax { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
