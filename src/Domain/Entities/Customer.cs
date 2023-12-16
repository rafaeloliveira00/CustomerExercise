namespace Connectlime.Domain.Entities;

public abstract class Customer : BaseAuditableEntity
{
    public string? Name { get; init; }
    public string? Email { get; set; }

    public abstract string? GetIdentificationNumber();
}
