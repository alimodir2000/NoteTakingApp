using NoteTakingAppSolution.Application.Common.Exceptions;
using NoteTakingAppSolution.Domain.Entities;
using MediatR;
using NoteTakingAppSolution.Application.Common.Persistence;

namespace NoteTakingAppSolution.Application.Notebooks.Commands.UpdateNotebook;

public record UpdateNotebookCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }
}

public class UpdateNotebookCommandHandler : IRequestHandler<UpdateNotebookCommand>
{
    private readonly INotebookRepository _notebookRepository;

    public UpdateNotebookCommandHandler(INotebookRepository notebookRepository)
    {
        _notebookRepository = notebookRepository;
    }

    public async Task<Unit> Handle(UpdateNotebookCommand request, CancellationToken cancellationToken)
    {
        var entity = await _notebookRepository.GetByIdAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Notebook), request.Id);
        }

        entity.Title = request.Title;

        await _notebookRepository.UpdateAsync(entity);

        return Unit.Value;
    }
}
