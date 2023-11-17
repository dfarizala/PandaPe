using MediatR;
using PandaPeTest.Api.Domain.DTO;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Update
{
    public class UpdateCandidateCommand : IRequest<int>
    {
        public CandidatesDTO Request { get; set; }
    }
}
