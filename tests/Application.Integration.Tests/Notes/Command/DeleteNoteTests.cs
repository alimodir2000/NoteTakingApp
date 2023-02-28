using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Routing;
using NoteTakingAppSolution.Application.Common.Exceptions;
using NoteTakingAppSolution.Application.Notebooks.Commands.CreateNotebook;
using NoteTakingAppSolution.Application.Notes.Commands.CreateNote;
using NoteTakingAppSolution.Application.Notes.Commands.DeleteNote;
using NoteTakingAppSolution.Domain.Entities;
using Presentation.Web.Api;

namespace Application.Integration.Tests.Notes.Command
{
    public class DeleteNoteTests : BaseTesting
    {
        public DeleteNoteTests(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ShouldRequireValidNoteId()
        {
            var command = new DeleteNoteCommand(99);

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task ShouldDeleteTodoItem()
        {
            var notebookId = await SendAsync(new CreateNotebookCommand
            {
                Title = "New List"
            });

            var noteId = await SendAsync(new CreateNoteCommand
            {
                NotebookId = notebookId,
                Title = "New Item"
            });

            await SendAsync(new DeleteNoteCommand(noteId));

            var item = await FindAsync<Note>(noteId);

            item.Should().BeNull();
        }
    }
}
