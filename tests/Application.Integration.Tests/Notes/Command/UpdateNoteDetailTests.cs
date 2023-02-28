using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NoteTakingAppSolution.Application.Common.Exceptions;
using NoteTakingAppSolution.Application.Notebooks.Commands.CreateNotebook;
using NoteTakingAppSolution.Application.Notes.Commands.CreateNote;
using NoteTakingAppSolution.Application.Notes.Commands.UpdateNote;
using NoteTakingAppSolution.Application.Notes.Commands.UpdateNoteDetail;
using NoteTakingAppSolution.Domain.Entities;
using Presentation.Web.Api;

namespace Application.Integration.Tests.Notes.Command
{
    public class UpdateNoteDetailTests : BaseTesting
    {
        public UpdateNoteDetailTests(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ShouldRequireValidNoteId()
        {
            var command = new UpdateNoteCommand { Id = 99, Title = "New Title" };
            await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task ShouldUpdateNoteDetail()
        {
            var userId = await RunAsDefaultUserAsync();

            var notebookId = await SendAsync(new CreateNotebookCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateNoteCommand
            {
                NotebookId = notebookId,
                Title = "New Item"
            });

            var command = new UpdateNoteDetailCommand
            {
                Id = itemId,
                NotebookId = notebookId,
                Note = "This is the note.",

            };

            await SendAsync(command);

            var item = await FindAsync<Note>(itemId);

            item.Should().NotBeNull();
            item!.NotebookId.Should().Be(command.NotebookId);
            item.NoteBody.Should().Be(command.Note);
            item.LastModified.Should().NotBeNull();
            item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        }
    }
}
