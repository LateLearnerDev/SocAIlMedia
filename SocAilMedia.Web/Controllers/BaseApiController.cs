
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SocAilMedia.Web.Controllers;

[ApiController]
[Route("web/[controller]")]
public class BaseApiController : Controller
{
    protected BaseApiController(IMediator mediator)
    {
        Mediator = mediator;
    }

    protected IMediator Mediator { get; }

    // private IMediator? _mediator;
    //
    // protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}