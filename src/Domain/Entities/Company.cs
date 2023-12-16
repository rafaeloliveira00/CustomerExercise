namespace Connectlime.Domain.Entities;

public sealed class Company : Customer
{
    public string? Nipc { get; init; }

    public IList<Transaction> Transactions { get; private set; } = new List<Transaction>();

    public override string? GetIdentificationNumber()
    {
        return Nipc;
    }
}
