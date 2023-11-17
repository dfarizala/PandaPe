using MediatR;
using PandaPeTest.Api.Domain.DTO;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Create
{
    public class CreateCandidateCommand : IRequest<int>
    {
        public CandidatesDTO Request { get; set; }
    }
}
