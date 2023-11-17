using MediatR;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Delete
{
    public class DeleteExperienceByIdCommand : IRequest<bool>
    {
        public int ExperienceId { get; set; }
    }
}
