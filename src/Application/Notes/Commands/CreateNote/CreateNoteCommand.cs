using NoteTakingAppSolution.Domain.Entities;
using NoteTakingAppSolution.Domain.Events;
using MediatR;
using NoteTakingAppSolution.Application.Common.Persistence;

namespace NoteTakingAppSolution.Application.Notes.Commands.CreateNote;

public record CreateNoteCommand : IRequest<int>
{
    public int NotebookId { get; init; }
    public string? Title { get; init; }
    public string? Body { get; set; }
}

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, int>
{
    private readonly INoteRepository _noteRepository;

    public CreateNoteCommandHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<int> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = new Note
        {
            NotebookId = request.NotebookId,
            Title = request.Title,
            NoteBody = request.Body,

        };

        entity.AddDomainEvent(new NoteCreatedEvent(entity));

        await _noteRepository.AddAsync(entity, cancellationToken);
        return entity.Id;
    }
}

