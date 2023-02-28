using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Web.Api.Controllers;
/// <summary>
/// Base Controller class for api. It allow access to Mediator 
/// </summary>

[Route("api/[controller]")]
[ApiController]
public class ApiBaseController : ControllerBase
{
    private ISender? _mediator;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
