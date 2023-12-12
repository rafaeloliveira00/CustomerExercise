using Connectlime.Application.Common.Models;
using Connectlime.Application.Companies.Commands.CreateCompany;
using Connectlime.Application.Companies.Commands.UpdateCompany;
using Connectlime.Application.Companies.Queries;

namespace Connectlime.Web.Endpoints;

public class Companies : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this, "company")
            .MapGet(GetCompany, "{id}")
            .MapGet(GetCompaniesWithPagination)
            .MapPost(CreateCompany)
            .MapPut(UpdateCompany, "{id}");
    }

    public async Task<dynamic> GetCompany(ISender sender, int id)
    {
        CompanyDto? company = await sender.Send(new GetCompanyQuery { Id = id });

        return company != null
            ? company
            : Results.NotFound();
    }

    public async Task<PaginatedList<CompanyDto>> GetCompaniesWithPagination(ISender sender, [AsParameters] GetCompaniesWithPaginationQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateCompany(ISender sender, CreateCompanyCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateCompany(ISender sender, int id, UpdateCompanyCommand command)
    {
        if (id != command.Id)
        {
            return Results.BadRequest();
        }

        await sender.Send(command);

        return Results.NoContent();
    }
}
