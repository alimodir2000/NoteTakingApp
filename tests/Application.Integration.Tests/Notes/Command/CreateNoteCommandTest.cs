using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NoteTakingAppSolution.Application.Common.Exceptions;
using NoteTakingAppSolution.Application.Notebooks.Commands.CreateNotebook;
using NoteTakingAppSolution.Application.Notes.Commands.CreateNote;
using NoteTakingAppSolution.Domain.Entities;
using Presentation.Web.Api;



namespace Application.Integration.Tests.Notes.Command
{

    public class CreateNoteCommandTest : BaseTesting
    {
        public CreateNoteCommandTest(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ShouldRequireMinimumFields()
        {
            var command = new CreateNoteCommand();

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Fact]
        public async Task ShouldCreateNote()
        {
            var userId = await RunAsDefaultUserAsync();

            var notebookId = await SendAsync(new CreateNotebookCommand
            {
                Title = "New Notebook"
            });

            var command = new CreateNoteCommand
            {
                NotebookId = notebookId,
                Title = "Tasks"
            };

            var itemId = await SendAsync(command);

            var item = await FindAsync<Note>(itemId);

            item.Should().NotBeNull();
            item!.NotebookId.Should().Be(command.NotebookId);
            item.Title.Should().Be(command.Title);
            item.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
            item.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        }



    }
}