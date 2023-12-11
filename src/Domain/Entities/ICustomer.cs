namespace Connectlime.Domain.Entities;

public interface ICustomer
{
    public string? Name { get; init; }
    public string? Email { get; set; }

    public string? GetIdentificationNumber();
}
