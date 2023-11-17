using PandaPeTest.Api.Domain.DTO;

namespace PandaPeTest.Api.Application.Features.Candidates.Queries.Get
{
    public class GetCandidateByIdResponse
    {
        public CandidatesDTO Candidate { get; set; }
        public List<CandidateExperiencesDTO>? Experiences { get; set; }
    }
}
