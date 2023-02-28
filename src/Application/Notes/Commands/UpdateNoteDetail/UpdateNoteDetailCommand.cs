using NoteTakingAppSolution.Application.Common.Exceptions;
using NoteTakingAppSolution.Domain.Entities;
using MediatR;
using NoteTakingAppSolution.Application.Common.Persistence;

namespace NoteTakingAppSolution.Application.Notes.Commands.UpdateNoteDetail;

public record UpdateNoteDetailCommand : IRequest
{
    public int Id { get; init; }

    public int NotebookId { get; init; }

    public string? Note { get; init; }
}

public class UpdateNoteDetailCommandHandler : IRequestHandler<UpdateNoteDetailCommand>
{
    private readonly INoteRepository _noteRepository;

    public UpdateNoteDetailCommandHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<Unit> Handle(UpdateNoteDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _noteRepository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        entity.NotebookId = request.NotebookId;
        entity.NoteBody = request.Note;

        await _noteRepository.UpdateAsync(entity, cancellationToken);

        return Unit.Value;
    }
}
