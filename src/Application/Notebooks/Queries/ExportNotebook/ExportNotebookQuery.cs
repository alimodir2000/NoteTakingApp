using AutoMapper;
using AutoMapper.QueryableExtensions;
using NoteTakingAppSolution.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NoteTakingAppSolution.Application.Common.Persistence;
using NoteTakingAppSolution.Application.Notebooks.Queries.ExportNotebook;

namespace NoteTakingAppSolution.Application.Notebooks.Queries.ExportNotebook;

public record ExportNotebookQuery : IRequest<ExportNotebookVm>
{
    public int NotebookId { get; init; }
}

public class ExportNotebookHandler : IRequestHandler<ExportNotebookQuery, ExportNotebookVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICsvFileBuilder _fileBuilder;

    public ExportNotebookHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
    }

    public async Task<ExportNotebookVm> Handle(ExportNotebookQuery request, CancellationToken cancellationToken)
    {
        var records = await _context.Notes
                .Where(t => t.NotebookId == request.NotebookId)
                .ProjectTo<ExportNotebookRecord>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        var vm = new ExportNotebookVm(
            "TodoItems.csv",
            "text/csv",
            _fileBuilder.BuildNotebookFile(records));

        return vm;
    }
}
