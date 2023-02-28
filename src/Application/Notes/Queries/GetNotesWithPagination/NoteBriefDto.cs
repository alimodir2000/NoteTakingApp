using NoteTakingAppSolution.Application.Common.Mappings;
using NoteTakingAppSolution.Domain.Entities;

namespace NoteTakingAppSolution.Application.Notes.Queries.GetNotesWithPagination;

public class NoteBriefDto : IMapFrom<Note>
{
    public int Id { get; set; }

    public int NotebookId { get; set; }

    public string? Title { get; set; }

    public string? NoteBody { get; set; }



}
