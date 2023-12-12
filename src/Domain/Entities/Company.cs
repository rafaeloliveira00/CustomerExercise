namespace Connectlime.Domain.Entities;

public sealed class Company : BaseAuditableEntity, ICustomer
{
    public string? Name { get; init; }
    public string? Email { get; set; }
    public string? Nipc { get; init; }

    public IList<Transaction> Transactions { get; private set; } = new List<Transaction>();

    public string? GetIdentificationNumber()
    {
        return Nipc;
    }
}
