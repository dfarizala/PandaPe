using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Delete
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeleteExperienceByIdController : Controller
    {
        private readonly IMediator _Mediator;

        public DeleteExperienceByIdController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        async public Task<IActionResult> DeleteById([FromBody] string IdExperience)
        {
            DeleteExperienceByIdCommand Command = new DeleteExperienceByIdCommand { ExperienceId = Convert.ToInt32(IdExperience) };
            return Ok(await _Mediator.Send(Command));
        }
    }
}
