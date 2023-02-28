using NoteTakingAppSolution.Domain.Entities;
using MediatR;
using NoteTakingAppSolution.Application.Common.Persistence;

namespace NoteTakingAppSolution.Application.Notebooks.Commands.CreateNotebook;

public record CreateNotebookCommand : IRequest<int>
{
    public string? Title { get; init; }
}

public class CreateNotebookCommandHandler : IRequestHandler<CreateNotebookCommand, int>
{
    private readonly INotebookRepository _notebookRepository;

    public CreateNotebookCommandHandler(INotebookRepository notebookRepository)
    {
        _notebookRepository = notebookRepository;
    }

    public async Task<int> Handle(CreateNotebookCommand request, CancellationToken cancellationToken)
    {
        var entity = new Notebook();

        entity.Title = request.Title;

        await _notebookRepository.AddAsync(entity);

        return entity.Id;
    }
}
