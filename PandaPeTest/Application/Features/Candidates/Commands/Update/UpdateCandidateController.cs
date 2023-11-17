using MediatR;
using Microsoft.AspNetCore.Mvc;
using PandaPeTest.Api.Domain.DTO;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Update
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateCandidateController : Controller
    {
        private readonly IMediator _Mediator;

        public UpdateCandidateController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        async public Task<IActionResult> Post([FromBody] CandidatesDTO Request)
        {
            UpdateCandidateCommand Command = new UpdateCandidateCommand { Request = Request };
            return Ok(await _Mediator.Send(Command));
        }
    }
}
