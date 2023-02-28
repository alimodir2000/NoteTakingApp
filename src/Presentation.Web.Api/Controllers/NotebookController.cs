using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteTakingAppSolution.Application.Notebooks.Commands.CreateNotebook;
using NoteTakingAppSolution.Application.Notebooks.Commands.DeleteNotebook;
using NoteTakingAppSolution.Application.Notebooks.Commands.UpdateNotebook;
using NoteTakingAppSolution.Application.Notebooks.Queries.ExportNotebook;
using NoteTakingAppSolution.Application.TodoLists.Queries.GetTodos;

namespace Presentation.Web.Api.Controllers;

/// <summary>
/// Notebook Controller class
/// all CRUD operations related to the notebook implemented in this class. 
/// I uses restfull principles
/// The logic is pretty simple: the api uses Mediator and send appropriate command request.
/// This request will handle by its handler that defined in Application
/// </summary>

[Route("api/[controller]")]
[ApiController]
public class NotebookController : ApiBaseController
{
    /// <summary>
    /// Return list of the nootbooks
    /// </summary>
    /// <returns>List of the notebooks</returns>
    [HttpGet]
    public async Task<ActionResult<NotebooksVm>> Get()
    {
        return await Mediator.Send(new GetNotebooksQuery());
    }

    /// <summary>
    /// Return the requested notebook by its id
    /// </summary>
    /// <param name="id">id of notebook to be reterive</param>
    /// <returns>File of the notes in CSV format</returns>
    [HttpGet("{id}")]
    public async Task<FileResult> Get(int id)
    {
        var vm = await Mediator.Send(new ExportNotebookQuery { NotebookId = id });

        return File(vm.Content, vm.ContentType, vm.FileName);
    }

    /// <summary>
    /// Create a notebook
    /// </summary>
    /// <param name="command">Title of the notebook</param>
    /// <returns>New notebook id</returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateNotebookCommand command)
    {
        return await Mediator.Send(command);
    }

    /// <summary>
    /// Update the requested notebook
    /// </summary>
    /// <param name="id">the id of notebook to be updated</param>
    /// <param name="command">it consists of title of the notebook and notebook id</param>
    /// <returns>NoContent</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateNotebookCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// Delete the notebook and its notes by its id
    /// </summary>
    /// <param name="id">id of notebook to be deleted</param>
    /// <returns>NoContent</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteNotebookCommand(id));

        return NoContent();
    }
}
