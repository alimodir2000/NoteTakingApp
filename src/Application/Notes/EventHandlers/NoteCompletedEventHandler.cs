using NoteTakingAppSolution.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace NoteTakingAppSolution.Application.Notes.EventHandlers;

public class NoteCompletedEventHandler : INotificationHandler<NoteCompletedEvent>
{
    private readonly ILogger<NoteCompletedEventHandler> _logger;

    public NoteCompletedEventHandler(ILogger<NoteCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(NoteCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("NoteTakingAppSolution Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
