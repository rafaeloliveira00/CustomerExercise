namespace Connectlime.Domain.Entities;

public sealed class Person : Customer
{
    public string? Nif { get; init; }

    public IList<Transaction> Transactions { get; private set; } = new List<Transaction>();

    public override string? GetIdentificationNumber()
    {
        return Nif;
    }
}
