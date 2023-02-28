using AutoMapper;
using AutoMapper.QueryableExtensions;
using NoteTakingAppSolution.Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NoteTakingAppSolution.Application.Common.Persistence;

namespace NoteTakingAppSolution.Application.TodoLists.Queries.GetTodos;

public record GetNotebooksQuery : IRequest<NotebooksVm>;

public class GetNotebooksQueryHandler : IRequestHandler<GetNotebooksQuery, NotebooksVm>
{
    private readonly INotebookRepository _notebookRepository;
    private readonly IMapper _mapper;

    public GetNotebooksQueryHandler(IMapper mapper, INotebookRepository notebookRepository)
    {       
        _mapper = mapper;
        _notebookRepository = notebookRepository;
    }

    public async Task<NotebooksVm> Handle(GetNotebooksQuery request, CancellationToken cancellationToken)
    {
        var data = await _notebookRepository.GetAllAsync();        
        var notebooks = data.AsQueryable().OrderBy(x => x.Title).ToList();

        return new NotebooksVm
        {            
            NotebookList = _mapper.Map<List<NotebookDto>>(notebooks),
        };
    }
}
