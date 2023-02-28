namespace NoteTakingAppSolution.Domain.Entities;
/// <summary>
/// Represent Note entity. Every entity has a unique integer id associate with a Title, and Body.
/// It also can be assigned to a notebook as well. 
/// 
/// </summary>
public class Note : BaseAuditableEntity
{
    public int NotebookId { get; set; }

    public string? Title { get; set; }

    public string? NoteBody { get; set; }

    public Notebook Notebook { get; set; } = null!;
}
