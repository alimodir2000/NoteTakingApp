using NoteTakingAppSolution.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace NoteTakingAppSolution.Application.Notes.EventHandlers;

public class NoteCreatedEventHandler : INotificationHandler<NoteCreatedEvent>
{
    private readonly ILogger<NoteCreatedEventHandler> _logger;

    public NoteCreatedEventHandler(ILogger<NoteCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(NoteCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("NoteTakingAppSolution Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
