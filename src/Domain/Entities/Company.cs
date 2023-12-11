namespace Connectlime.Domain.Entities;

public sealed class Company : BaseAuditableEntity, ICustomer
{
    public string? Name { get; init; }
    public string? Email { get; set; }
    public string? Nipc { get; init; }

    public string? GetIdentificationNumber()
    {
        return Nipc;
    }
}
