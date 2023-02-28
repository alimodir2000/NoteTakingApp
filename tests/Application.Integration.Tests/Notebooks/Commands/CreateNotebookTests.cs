using NoteTakingAppSolution.Application.Common.Exceptions;
using NoteTakingAppSolution.Domain.Entities;
using FluentAssertions;

using NoteTakingAppSolution.Application.Notebooks.Commands.CreateNotebook;
using Application.Integration.Tests;
using Microsoft.AspNetCore.Mvc.Testing;
using Presentation.Web.Api;

namespace Application.Integration.Tests.Notebooks.Commands;



public class CreateNotebookTests : BaseTesting
{
    public CreateNotebookTests(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateNotebookCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

  

    [Fact]
    public async Task ShouldCreateNotebook()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateNotebookCommand
        {
            Title = "Tasks"
        };

        var id = await SendAsync(command);

        var notebook = await FindAsync<Notebook>(id);

        notebook.Should().NotBeNull();
        notebook!.Title.Should().Be(command.Title);
        notebook.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
