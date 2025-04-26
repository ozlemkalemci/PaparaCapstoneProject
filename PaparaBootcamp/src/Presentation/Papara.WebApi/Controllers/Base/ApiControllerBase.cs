using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Papara.WebApi.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
	private ISender? _mediator;

	protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}