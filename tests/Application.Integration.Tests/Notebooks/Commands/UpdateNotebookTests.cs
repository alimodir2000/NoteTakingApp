using NoteTakingAppSolution.Application.Common.Exceptions;
using NoteTakingAppSolution.Domain.Entities;
using FluentAssertions;
using NoteTakingAppSolution.Application.Notebooks.Commands.UpdateNotebook;
using NoteTakingAppSolution.Application.Notebooks.Commands.CreateNotebook;
using Microsoft.AspNetCore.Mvc.Testing;
using Presentation.Web.Api;

namespace Application.Integration.Tests.Notebooks.Commands;
public class UpdateNotebookTests : BaseTesting
{
    public UpdateNotebookTests(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new UpdateNotebookCommand { Id = 99, Title = "New Title" };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }
        

    [Fact]
    public async Task ShouldUpdateTodoList()
    {
        var userId = await RunAsDefaultUserAsync();

        var notebookId = await SendAsync(new CreateNotebookCommand
        {
            Title = "New Notebook"
        });

        var command = new UpdateNotebookCommand
        {
            Id = notebookId,
            Title = "Updated Notebook"
        };

        await SendAsync(command);

        var list = await FindAsync<Notebook>(notebookId);

        list.Should().NotBeNull();
        list!.Title.Should().Be(command.Title);
        list.LastModifiedBy.Should().NotBeNull();
        list.LastModifiedBy.Should().Be(userId);
        list.LastModified.Should().NotBeNull();
        list.LastModified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
