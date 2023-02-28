using NoteTakingAppSolution.Application.Common.Exceptions;
using NoteTakingAppSolution.Domain.Entities;
using MediatR;
using NoteTakingAppSolution.Application.Common.Persistence;

namespace NoteTakingAppSolution.Application.Notes.Commands.UpdateNote;

public record UpdateNoteCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public string? Body { get; init; }

}

public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
{
    private readonly INoteRepository _noteRepository;

    public UpdateNoteCommandHandler(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _noteRepository.GetByIdAsync(request.Id, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Note), request.Id);
        }

        entity.Title = request.Title;
        entity.NoteBody = request.Body;

        await _noteRepository.UpdateAsync(entity);

        return Unit.Value;
    }
}
