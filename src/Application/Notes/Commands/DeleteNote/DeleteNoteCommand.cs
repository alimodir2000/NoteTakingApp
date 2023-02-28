using NoteTakingAppSolution.Application.Common.Exceptions;
using NoteTakingAppSolution.Domain.Entities;
using NoteTakingAppSolution.Domain.Events;
using MediatR;
using NoteTakingAppSolution.Application.Common.Persistence;

namespace NoteTakingAppSolution.Application.Notes.Commands.DeleteNote;

public record DeleteNoteCommand(int Id) : IRequest;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
{
    private readonly INoteRepository _noteRepository;

    public DeleteNoteCommandHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _noteRepository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        await _noteRepository.DeleteAsync(entity, cancellationToken);

        entity.AddDomainEvent(new NoteDeletedEvent(entity));

        return Unit.Value;
    }
}
