using Connectlime.Application.Common.Models;
using Connectlime.Application.Transactions.Commands;
using Connectlime.Application.Transactions.Queries;

namespace Connectlime.Web.Endpoints;

public class Transactions : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this, "transaction")
            .MapGet(GetTransactions)
            .MapPost(CreateTransaction);
    }

    public async Task<PaginatedList<TransactionDto>> GetTransactions(ISender sender, [AsParameters] GetTransactionWithPaginationQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateTransaction(ISender sender, CreateTransactionCommand command)
    {
        return await sender.Send(command);
    }
}
