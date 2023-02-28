using NoteTakingAppSolution.Application.TodoLists.Queries.GetTodos;
using NoteTakingAppSolution.Domain.Entities;
using NoteTakingAppSolution.Domain.ValueObjects;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Presentation.Web.Api;

namespace Application.Integration.Tests.Notebooks.Queries;



public class GetNotebookTests : BaseTesting
{
    public GetNotebookTests(WebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task ShouldReturnAllNotebooks()
    {
        await RunAsDefaultUserAsync();

        await AddAsync(new Notebook
        {
            Title = "Shopping",
            Colour = Colour.Blue,
            Notes =
                    {
                        new Note { Title = "Apples"},
                        new Note { Title = "Milk" },
                        new Note { Title = "Bread" },
                        new Note { Title = "Toilet paper" },
                        new Note { Title = "Pasta" },
                        new Note { Title = "Tissues" },
                        new Note { Title = "Tuna" }
                    }
        });

        await AddAsync(new Notebook
        {
            Title = "Science",
            Colour = Colour.Blue,
            Notes =
                    {
                        new Note { Title = "Computer", NoteBody = "It is multi disiplinary subject!"},
                    }
        });

        var query = new GetNotebooksQuery();

        var result = await SendAsync(query);

        result.NotebookList.Should().HaveCount(2);

    }

}
