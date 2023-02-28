using AutoMapper;
using AutoMapper.QueryableExtensions;
using NoteTakingAppSolution.Application.Common.Mappings;
using NoteTakingAppSolution.Application.Common.Models;
using MediatR;
using NoteTakingAppSolution.Application.Common.Persistence;
using NoteTakingAppSolution.Domain.Entities;

namespace NoteTakingAppSolution.Application.Notes.Queries.GetNotesWithPagination;

public record GetNotesWithPaginationQuery : IRequest<PaginatedList<NoteBriefDto>>
{
    public int NotebookId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetNotesWithPaginationQueryHandler : IRequestHandler<GetNotesWithPaginationQuery, PaginatedList<NoteBriefDto>>
{
    private readonly IMapper _mapper;
    private readonly INoteRepository _noteRepository;

    public GetNotesWithPaginationQueryHandler(IMapper mapper, INoteRepository noteRepository)
    {        
        _mapper = mapper;
        _noteRepository = noteRepository;
    }

    public async Task<PaginatedList<NoteBriefDto>> Handle(GetNotesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var notes = await _noteRepository.GetAsync(x=>x.NotebookId == request.NotebookId,  cancellationToken);        
        var data = _mapper.Map<List<NoteBriefDto>>(notes);
        return PaginatedList<NoteBriefDto>.Create(data, request.PageNumber, request.PageSize);

       
    }
}
