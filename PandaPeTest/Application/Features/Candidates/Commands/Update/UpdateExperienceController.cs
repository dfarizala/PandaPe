using MediatR;
using Microsoft.AspNetCore.Mvc;
using PandaPeTest.Api.Domain.DTO;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Update
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateExperienceController : Controller
    {
        private readonly IMediator _Mediator;

        public UpdateExperienceController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        async public Task<IActionResult> Post([FromBody] CandidateExperiencesDTO Request)
        {
            UpdateExperienceCommand Command = new UpdateExperienceCommand { Request = Request };
            return Ok(await _Mediator.Send(Command));
        }
    }
}
