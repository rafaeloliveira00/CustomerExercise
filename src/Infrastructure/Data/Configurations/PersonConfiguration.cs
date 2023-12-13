using Connectlime.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connectlime.Infrastructure.Data.Configurations;

public class Personfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(t => t.Name)
            .IsRequired();

        builder.Property(t => t.Nif)
            .IsRequired();
    }
}
