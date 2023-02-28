using NoteTakingAppSolution.Application.Common.Exceptions;
using NoteTakingAppSolution.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NoteTakingAppSolution.Application.Common.Persistence;

namespace NoteTakingAppSolution.Application.Notebooks.Commands.DeleteNotebook;

public record DeleteNotebookCommand(int Id) : IRequest;

public class DeleteNotebookCommandHandler : IRequestHandler<DeleteNotebookCommand>
{
    private readonly INotebookRepository _notebookRepository;
    private readonly INoteRepository _noteRepository;

    public DeleteNotebookCommandHandler(INotebookRepository notebookRepository, INoteRepository noteRepository)
    {
        _notebookRepository = notebookRepository;
        _noteRepository = noteRepository;
    }

    public async Task<Unit> Handle(DeleteNotebookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _notebookRepository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Notebook), request.Id);
        }

        await _noteRepository.DeleteAsync(x => x.NotebookId == entity.Id);
        await _notebookRepository.DeleteAsync(entity);

        return Unit.Value;
    }
}
