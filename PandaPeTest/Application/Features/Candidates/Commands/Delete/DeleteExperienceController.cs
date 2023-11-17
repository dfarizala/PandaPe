using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Delete
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteExperienceController : Controller
    {
        private readonly IMediator _Mediator;

        public DeleteExperienceController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        async public Task<IActionResult> Delete([FromBody] string CandidateId)
        {
            DeleteExperienceCommand Command = new DeleteExperienceCommand { IdCandidate = Convert.ToInt32(CandidateId) };
            return Ok(await _Mediator.Send(Command));
        }
    }
}

