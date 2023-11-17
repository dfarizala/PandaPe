using MediatR;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Delete
{
    public class DeleteExperienceCommand : IRequest<bool>
    {
        public int IdCandidate { get; set; }
    }
}

