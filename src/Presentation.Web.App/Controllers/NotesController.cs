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

/// <summary>
/// Note Controller class
/// all CRUD operations related to the note implemented in this class. 
/// UI (index view) makes ajax call to APIs defined here
/// The logic is pretty simple: the api uses Mediator and send appropriate command request.
/// This request will handle by its handler that defined in Application
/// </summary>


[ApiController]
[Route("api/[controller]")]
public class NotesController : BaseController
{

    /// <summary>
    /// Create new note
    /// Fires CreateNoteCommand and send back new note to caller
    /// </summary>
    /// <returns>NoteBriefDto</returns>
    [HttpPost]
    public async Task<ActionResult<NoteBriefDto>> CreateNote()
    {
        var title = DateTime.Now.ToShortTimeString();

        var createNoteCommand = new CreateNoteCommand()
        {
            Title = title
        };

        var noteId = await Mediator.Send(createNoteCommand);

        var note = new NoteBriefDto
        {
            Id = noteId,
            Title = title,
            NoteBody = "New Note!"
        };

        return note;
    }
    /// <summary>
    /// Update note by its id
    /// </summary>
    /// <param name="id">The id of the note to be updated</param>
    /// <param name="note">Note parametes to be updated</param>
    /// <returns>NoContent</returns>

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

    /// <summary>
    /// Delete note by its id
    /// </summary>
    /// <param name="id">The id of note to be deleted!</param>
    /// <returns>NoContent</returns>

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNoteById(int id)
    {
        var deleteNoteCommand = new DeleteNoteCommand(id);
        await Mediator.Send(deleteNoteCommand);

        return NoContent();
    }

}

