using Connectlime.Domain.Entities;

namespace Connectlime.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Person> Persons { get; }

    DbSet<Company> Companies { get; }

    DbSet<Transaction> Transactions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
