using System.Diagnostics;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoteTakingAppSolution.Application.Notes.Queries.GetNotesWithPagination;
using Presentation.Web.App.Models;

namespace Presentation.Web.App.Controllers;
public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;


    public HomeController(ILogger<HomeController> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var notes = await _mediator.Send(new GetNotesWithPaginationQuery()
        {
            NotebookId = 1,
            PageNumber = 1,
            PageSize = 10
        });

       

        return View(notes);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
