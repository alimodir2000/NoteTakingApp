using NoteTakingAppSolution.Application.Common.Mappings;
using NoteTakingAppSolution.Domain.Entities;

namespace NoteTakingAppSolution.Application.TodoLists.Queries.GetTodos;

public class NotebookDto : IMapFrom<Notebook>
{
   
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Colour { get; set; }

    
}
