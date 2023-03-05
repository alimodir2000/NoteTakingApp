using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteTakingAppSolution.Application.Common.Models;
using NoteTakingAppSolution.Application.Notes.Commands.CreateNote;
using NoteTakingAppSolution.Application.Notes.Commands.DeleteNote;
using NoteTakingAppSolution.Application.Notes.Commands.UpdateNote;
using NoteTakingAppSolution.Application.Notes.Commands.UpdateNoteDetail;
using NoteTakingAppSolution.Application.Notes.Queries.GetNotesWithPagination;

namespace Presentation.Web.Api.Controllers;
/// <summary>
/// Note Controller class
/// all CRUD operations related to the note implemented in this class. 
/// I uses restfull principles
/// The logic is pretty simple: the api uses Mediator and send appropriate command request.
/// This request will handle by its handler that defined in Application
/// </summary>

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class NoteController : ApiBaseController
{
    /// <summary>
    /// This method will return notes in pagination format
    /// </summary>
    /// <param name="query">Consists of pagesize, notebook id and page number</param>
    /// <returns>Return paginated List of notes</returns>
    [HttpGet]
    public async Task<ActionResult<PaginatedList<NoteBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetNotesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    /// <summary>
    /// Initiate a creation node command and send it via Mediator. Command handler defined in the Application
    /// </summary>
    /// <param name="command">It consists NotebookID, Title and Body of the note</param>
    /// <returns>return the ID of new note</returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateNoteCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// Update note for node with requested id
    /// </summary>
    /// <param name="id">The node with the id will be updated</param>
    /// <param name="command">It consists NotebookID, Title and Body of the note</param>
    /// <returns>NoContent</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateNoteCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Update note in the notebook!
    /// </summary>
    /// <param name="id">the id of note to be updated</param>
    /// <param name="command">It consists of noteid, notebookId and the body of the note!</param>
    /// <returns>NoContent</returns>
    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateNoteDetails(int id, UpdateNoteDetailCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// This will delete the note by its id
    /// </summary>
    /// <param name="id">the note with this id will be deleted</param>
    /// <returns>NoContent</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteNoteCommand(id));
        return NoContent();
    }
}
