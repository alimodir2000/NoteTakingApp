using System.Diagnostics;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NoteTakingAppSolution.Application.Notes.Queries.GetNotesWithPagination;
using Presentation.Web.App.Models;

namespace Presentation.Web.App.Controllers;
public class HomeController : BaseController
{
    
    public HomeController()
    {
        
    }

    public async Task<IActionResult> Index()
    {
        return View(null);
    }

}
