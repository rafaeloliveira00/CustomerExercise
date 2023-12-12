using Connectlime.Application.Common.Models;
using Connectlime.Application.Persons.Commands.CreatePerson;
using Connectlime.Application.Persons.Commands.UpdatePerson;
using Connectlime.Application.Persons.Queries.GetPersons;
using Connectlime.Application.TodoItems.Commands.UpdateTodoItemDetail;

namespace Connectlime.Web.Endpoints;

public class Persons : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this, "person")
            .MapGet(GetPerson, "{id}")
            .MapGet(GetPersonsWithPagination)
            .MapPost(CreatePerson)
            .MapPut(UpdatePerson, "{id}");
    }

    public async Task<dynamic> GetPerson(ISender sender, int id)
    {
        PersonDto? person = await sender.Send(new GetPersonQuery { Id = id });

        return person != null
            ? person
            : Results.NotFound();
    }

    public async Task<PaginatedList<PersonDto>> GetPersonsWithPagination(ISender sender, [AsParameters] GetPersonsWithPaginationQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreatePerson(ISender sender, CreatePersonCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdatePerson(ISender sender, int id, UpdatePersonCommand command)
    {
        if (id != command.Id)
        {
            return Results.BadRequest();
        }

        await sender.Send(command);

        return Results.NoContent();
    }
}
