namespace NoteTakingAppSolution.Application.TodoLists.Queries.GetTodos;

public class NotebooksVm
{
    //public IList<PriorityLevelDto> PriorityLevels { get; set; } = new List<PriorityLevelDto>();

    public IList<NotebookDto> NotebookList { get; set; } = new List<NotebookDto>();
}
