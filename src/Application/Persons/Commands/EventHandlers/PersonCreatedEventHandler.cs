using Connectlime.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Connectlime.Application.Persons.Commands.EventHandlers;

public class PersonCreatedEventHandler : INotificationHandler<PersonCreatedEvent>
{
    private readonly ILogger<PersonCreatedEventHandler> _logger;

    public PersonCreatedEventHandler(ILogger<PersonCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(PersonCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Connectlime Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
