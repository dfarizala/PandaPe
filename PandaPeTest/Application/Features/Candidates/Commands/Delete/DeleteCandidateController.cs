using MediatR;
using Microsoft.AspNetCore.Mvc;
using PandaPeTest.Api.Application.Features.Candidates.Commands.Create;
using PandaPeTest.Api.Domain.DTO;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Delete
{
    [ApiController]
    [Route("api/[controller]")]

    public class DeleteCandidateController : Controller
    {
        private readonly IMediator _Mediator;

        public DeleteCandidateController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        async public Task<IActionResult> Delete([FromBody] string CandidateId)
        {
            DeleteCandidateCommand Command = new DeleteCandidateCommand { IdCandidate = Convert.ToInt32(CandidateId) };
            return Ok(await _Mediator.Send(Command));
        }
    }
}
