namespace NoteTakingAppSolution.Domain.Events;

public class NoteCompletedEvent : BaseEvent
{
    public NoteCompletedEvent(Note item)
    {
        Item = item;
    }

    public Note Item { get; }
}
