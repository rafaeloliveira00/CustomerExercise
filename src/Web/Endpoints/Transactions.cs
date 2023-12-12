using Connectlime.Application.Transactions.Commands;

namespace Connectlime.Web.Endpoints;

public class Transactions : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this, "transaction")
            .MapPost(CreateTransaction);
    }

    public async Task<int> CreateTransaction(ISender sender, CreateTransactionCommand command)
    {
        return await sender.Send(command);
    }
}
