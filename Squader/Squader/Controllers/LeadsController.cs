using Application.DomainActions.Lead.Commands.Accept;
using Application.DomainActions.Lead.Commands.Decline;
using Application.DomainActions.Lead.Querys.Accepted;
using Application.DomainActions.Lead.Querys.Invited;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Controllers.Lead
{
	[ApiController]
	[Route("api/[controller]")]
	public class LeadsController : ControllerBase
	{
		[HttpGet("Invited")]
		public async Task<ActionResult> GetInvited([FromServices] IMediator mediator) 
		{
			var result = await mediator.Send(new InvitedLeadQuery());

			return result is null ? BadRequest(result) : Ok(result);
		}

		[HttpGet("Accepted")]
		public async Task<ActionResult> GetAccepted([FromServices] IMediator mediator)
		{
			var result = await mediator.Send(new AcceptedLeadQuery());
			
			return result is null ?  BadRequest(result) : Ok(result);
		}

		[HttpPost("Accept")]
		public async Task<ActionResult> Accept([FromBody] AcceptLeadCommand command, [FromServices] IMediator mediator)
		{
			var result = await mediator.Send(command);
			return result ? Ok(result) : BadRequest(result);
		}

		[HttpPost("Decline")]
		public async Task<ActionResult> Decline([FromBody] DeclineLeadCommand command , [FromServices] IMediator mediator) 
		{
			var result = await mediator.Send(command);
			return result ? Ok(result) : BadRequest(result);
		} 
	}
}
