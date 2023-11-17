using MediatR;
using PandaPeTest.Api.Domain.DTO;

namespace PandaPeTest.Api.Application.Features.Candidates.Queries.Get
{
    public class GetCandidateByIdQuery : IRequest<GetCandidateByIdResponse>
    {
        public int CandidateId { get; set; }
    }
}
