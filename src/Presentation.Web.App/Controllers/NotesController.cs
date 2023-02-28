using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoteTakingAppSolution.Application.Notes.Commands.CreateNote;
using NoteTakingAppSolution.Application.Notes.Commands.DeleteNote;
using NoteTakingAppSolution.Application.Notes.Commands.UpdateNote;
using NoteTakingAppSolution.Application.Notes.Queries.GetNotesWithPagination;
using NoteTakingAppSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Web.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private ISender? _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
    //{
    //    return await _context.Notes.ToListAsync();
    //}

    //[HttpGet("{id}")]
    //public async Task<ActionResult<Note>> GetNoteById(int id)
    //{
    //    var note = await _context.Notes.FindAsync(id);

    //    if (note == null)
    //    {
    //        return NotFound();
    //    }

    //    return note;
    //}

    [HttpPost]
    public async Task<ActionResult<Note>> CreateNote()
    {
        var title = DateTime.Now.ToShortTimeString();

        var createNoteCommand = new CreateNoteCommand()
        {
            Title = title
        };

       var noteId = await Mediator.Send(createNoteCommand);

        var note = new Note
        {
            Id = noteId,
            Title = title,
            NoteBody = "New Note!"
        };

        return note;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(int id, [FromBody] NoteBriefDto note)
    {
        
        var updateCommand = new UpdateNoteCommand()
        {
            Id = id,
            Body = note.NoteBody,  
            Title = DateTime.Now.ToShortTimeString()
        };

        await Mediator.Send(updateCommand);


        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNoteById(int id)
    {
        var deleteNoteCommand = new DeleteNoteCommand(id);
        await Mediator.Send(deleteNoteCommand);

        return NoContent();
    }

    //private bool NoteExists(int id)
    //{
    //    return _context.Notes.Any(n => n.Id == id);
    //}
}

