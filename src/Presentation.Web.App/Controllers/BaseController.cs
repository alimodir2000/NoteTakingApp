using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Web.App.Controllers;
/// <summary>
/// Base Controller class. It allow access to Mediator 
/// </summary>
public class BaseController : Controller
{
    private ISender? _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
