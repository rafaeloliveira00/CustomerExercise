using Connectlime.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Connectlime.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        ApplicationDbContextInitialiser initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default data
        // Seed, if necessary

        if (!_context.Companies.Any())
        {
            _context.Companies.AddRange(
                new List<Company>()
                {
                    new()
                    {
                        Id = 1,
                        Name = "Company1",
                        Email = "company1@email.com",
                        Nipc = "123456789"
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Company2",
                        Email = "company2@email.com",
                        Nipc = "123456780"
                    }
                }
            );

            _context.Persons.AddRange(
                new List<Person>()
                {
                    new()
                    {
                        Id = 1,
                        Name = "Company1",
                        Email = "company1@email.com",
                        Nif = "123456789"
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Company2",
                        Email = "company2@email.com",
                        Nif = "123456780"
                    }
                }
            );

            _context.Transactions.AddRange(
                new List<Transaction>()
                {
                    new()
                    {
                        Id = 1,
                        CompanyId = 1,
                        PersonId = 2,
                        ProductId = Guid.NewGuid().ToString(),
                        UnitPrice = 50.30m,
                        Quantity = 21,
                        CompanyTax = 0.23m,
                        PersonTax = 0.29m
                    },
                    new()
                    {
                        Id = 2,
                        CompanyId = 1,
                        PersonId = 1,
                        ProductId = Guid.NewGuid().ToString(),
                        UnitPrice = 5.30m,
                        Quantity = 2,
                        CompanyTax = 0.23m,
                        PersonTax = 0.29m
                    },
                    new()
                    {
                        Id = 3,
                        CompanyId = 2,
                        PersonId = 1,
                        ProductId = Guid.NewGuid().ToString(),
                        UnitPrice = 20.30m,
                        Quantity = 261,
                        CompanyTax = 0.23m,
                        PersonTax = 0.29m
                    }
                }
            );

            await _context.SaveChangesAsync();
        }
    }
}
