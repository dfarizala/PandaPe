using MediatR;
using Microsoft.AspNetCore.Mvc;
using PandaPeTest.Api.Domain.DTO;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Create
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateCandidateController : Controller
    {
        private readonly IMediator _Mediator;

        public CreateCandidateController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        async public Task<IActionResult> Post([FromBody] CandidatesDTO Request)
        {
            CreateCandidateCommand Command = new CreateCandidateCommand { Request = Request };
            return Ok(await _Mediator.Send(Command));
        }
    }
}
