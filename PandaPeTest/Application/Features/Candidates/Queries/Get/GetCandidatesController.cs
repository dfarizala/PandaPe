using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PandaPeTest.Api.Application.Features.Candidates.Commands.Update;
using PandaPeTest.Api.Domain.DTO;

namespace PandaPeTest.Api.Application.Features.Candidates.Queries.Get
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetCandidatesController : Controller
    {
        private readonly IMediator _Mediator;

        public GetCandidatesController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        async public Task<IActionResult> Get()
        {
            GetCandidatesQuery Query = new GetCandidatesQuery();
            return Ok(await _Mediator.Send(Query));
        }

        [HttpGet]
        [Route("GetById/{IdCandidate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        async public Task<IActionResult> GetById(int IdCandidate)
        {
            GetCandidateByIdQuery Query = new GetCandidateByIdQuery { CandidateId = IdCandidate };
            return Ok(await _Mediator.Send(Query));
        }

        [HttpGet]
        [Route("GetExperienceById/{ExperienceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        async public Task<IActionResult> GetExperienceById(int ExperienceId)
        {
            GetExperienceByIdQuery Query = new GetExperienceByIdQuery { IdExperience = ExperienceId };
            return Ok(await _Mediator.Send(Query));
        }

    }
}
