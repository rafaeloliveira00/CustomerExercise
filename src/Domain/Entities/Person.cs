namespace Connectlime.Domain.Entities;

public sealed class Person : BaseAuditableEntity, ICustomer
{
    public string? Name { get; init; }
    public string? Email { get; set; }
    public string? Nif { get; init; }

    public IList<Transaction> Transactions { get; private set; } = new List<Transaction>();

    public string? GetIdentificationNumber()
    {
        return Nif;
    }
}
