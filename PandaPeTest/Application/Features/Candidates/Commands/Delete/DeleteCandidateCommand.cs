using MediatR;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Delete
{
    public class DeleteCandidateCommand : IRequest<bool>
    {
        public int IdCandidate { get; set; }
    }
}
