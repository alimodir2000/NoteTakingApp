namespace NoteTakingAppSolution.Domain.Entities;
/// <summary>
/// This class represents a notebook entity that has unique integer id, a title, a color and a list of notes
/// </summary>
public class Notebook : BaseAuditableEntity
{
    public string? Title { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<Note> Notes { get; private set; } = new List<Note>();
}
