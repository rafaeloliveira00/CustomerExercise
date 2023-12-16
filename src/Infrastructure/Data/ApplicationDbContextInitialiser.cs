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
            Company company1 = new()
            {
                Name = "Company1",
                Email = "company1@email.com",
                Nipc = "123456789"
            };

            Company company2 = new()
            {
                Name = "Company2",
                Email = "company2@email.com",
                Nipc = "123456780"
            };

            _context.Companies.AddRange(
                new List<Company>()
                {
                    company1,
                    company2
                }
            );

            Person person1 = new()
            {
                Name = "Company1",
                Email = "company1@email.com",
                Nif = "123456789"
            };
            Person person2 = new()
            {
                Name = "Company2",
                Email = "company2@email.com",
                Nif = "123456780"
            };

            _context.Persons.AddRange(
                new List<Person>()
                {
                    person1,
                    person2
                }
            );

            // save changes to fill the objects with the proper generated id's
            await _context.SaveChangesAsync();

            _context.Transactions.AddRange(
                new List<Transaction>()
                {
                    new()
                    {
                        CompanyId = company1.Id,
                        PersonId = person2.Id,
                        ProductId = Guid.NewGuid().ToString(),
                        UnitPrice = 50.30m,
                        Quantity = 21,
                        CompanyTax = 0.23m,
                        PersonTax = 0.29m
                    },
                    new()
                    {
                        CompanyId = company1.Id,
                        PersonId = person2.Id,
                        ProductId = Guid.NewGuid().ToString(),
                        UnitPrice = 5.30m,
                        Quantity = 2,
                        CompanyTax = 0.23m,
                        PersonTax = 0.29m
                    },
                    new()
                    {
                        CompanyId = company2.Id,
                        PersonId = person1.Id,
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
