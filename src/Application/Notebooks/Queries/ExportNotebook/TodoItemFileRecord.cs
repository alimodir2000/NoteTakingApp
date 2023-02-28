using NoteTakingAppSolution.Application.Common.Mappings;
using NoteTakingAppSolution.Domain.Entities;

namespace NoteTakingAppSolution.Application.Notebooks.Queries.ExportNotebook;

public class ExportNotebookRecord : IMapFrom<Note>
{
    public string? Title { get; set; }

}
