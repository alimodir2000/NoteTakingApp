using Microsoft.AspNetCore.Mvc;
using NoteTakingAppSolution.Application.Common.Models;
using NoteTakingAppSolution.Application.Notes.Commands.CreateNote;
using NoteTakingAppSolution.Application.Notes.Commands.DeleteNote;
using NoteTakingAppSolution.Application.Notes.Commands.UpdateNote;
using NoteTakingAppSolution.Application.Notes.Commands.UpdateNoteDetail;
using NoteTakingAppSolution.Application.Notes.Queries.GetNotesWithPagination;

namespace Presentation.Web.Api.Controllers;
public class NoteController : ApiBaseController
{

    [HttpGet]
    public async Task<ActionResult<PaginatedList<NoteBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetNotesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }


    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateNoteCommand command)
    {
        return await Mediator.Send(command);
    }

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

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteNoteCommand(id));

        return NoContent();
    }
}
