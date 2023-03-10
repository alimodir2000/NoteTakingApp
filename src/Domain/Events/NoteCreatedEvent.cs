namespace NoteTakingAppSolution.Domain.Events;
/// <summary>
/// This event is used to triger actions when a note created!
/// </summary>
public class NoteCreatedEvent : BaseEvent
{
    public NoteCreatedEvent(Note item)
    {
        Item = item;
    }

    public Note Item { get; }
}
