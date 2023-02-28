using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteTakingAppSolution.Application.Notebooks.Commands.CreateNotebook;
using NoteTakingAppSolution.Application.Notebooks.Commands.DeleteNotebook;
using NoteTakingAppSolution.Application.Notebooks.Commands.UpdateNotebook;
using NoteTakingAppSolution.Application.Notebooks.Queries.ExportNotebook;
using NoteTakingAppSolution.Application.TodoLists.Queries.GetTodos;

namespace Presentation.Web.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NotebookController : ApiBaseController
{
    [HttpGet]
    public async Task<ActionResult<NotebooksVm>> Get()
    {
        return await Mediator.Send(new GetNotebooksQuery());
    }

    [HttpGet("{id}")]
    public async Task<FileResult> Get(int id)
    {
        var vm = await Mediator.Send(new ExportNotebookQuery { NotebookId = id });

        return File(vm.Content, vm.ContentType, vm.FileName);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateNotebookCommand command)
    {
        return await Mediator.Send(command);
    }

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

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteNotebookCommand(id));

        return NoContent();
    }
}
