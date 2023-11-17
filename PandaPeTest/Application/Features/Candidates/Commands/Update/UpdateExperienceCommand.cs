using MediatR;
using PandaPeTest.Api.Domain.DTO;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Update
{
    public class UpdateExperienceCommand : IRequest<int>
    {
        public CandidateExperiencesDTO Request { get; set; }
    }
}
