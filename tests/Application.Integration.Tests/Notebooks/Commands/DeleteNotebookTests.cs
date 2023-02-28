using NoteTakingAppSolution.Application.Common.Exceptions;
using NoteTakingAppSolution.Domain.Entities;
using FluentAssertions;

using NoteTakingAppSolution.Application.Notebooks.Commands.DeleteNotebook;
using NoteTakingAppSolution.Application.Notebooks.Commands.CreateNotebook;
using Application.Integration.Tests;
using Microsoft.AspNetCore.Mvc.Testing;
using Presentation.Web.Api;

namespace Application.Integration.Tests.Notebooks.Commands;


public class DeleteNotebookTests : BaseTesting
{
    public DeleteNotebookTests(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task ShouldRequireValidNotebookId()
    {
        var command = new DeleteNotebookCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task ShouldDeleteNotebook()
    {
        var notebookId = await SendAsync(new CreateNotebookCommand
        {
            Title = "New Notebook!"
        });

        await SendAsync(new DeleteNotebookCommand(notebookId));

        var list = await FindAsync<Notebook>(notebookId);

        list.Should().BeNull();
    }
}
