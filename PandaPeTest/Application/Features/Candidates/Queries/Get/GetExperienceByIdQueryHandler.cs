using AutoMapper;
using MediatR;
using PandaPeTest.Api.Domain.DTO;
using PandaPeTest.Api.Domain.Interfaces;

namespace PandaPeTest.Api.Application.Features.Candidates.Queries.Get
{
    public class GetExperienceByIdQueryHandler :IRequestHandler<GetExperienceByIdQuery, CandidateExperiencesDTO>
    {
        private readonly IApplicationRepository<PandaPeTest.Api.Domain.Entities.CandidateExperiences> _ExperienceRepository;
        private readonly IMapper _Mapper;

        public GetExperienceByIdQueryHandler(IMapper mapper,
                                             IApplicationRepository<Domain.Entities.CandidateExperiences> experienceRepository)
        {
            _Mapper = mapper;
            _ExperienceRepository = experienceRepository;
        }

        public async Task<CandidateExperiencesDTO> Handle(GetExperienceByIdQuery request, CancellationToken cancellationToken)
        {
            CandidateExperiencesDTO Result = new();
            try
            {
                var Experiences = await _ExperienceRepository.GetAsync(x => x.IdCandidateExperience == request.IdExperience);
                Result = _Mapper.Map<CandidateExperiencesDTO>(Experiences.ToList()[0]);
            }
            catch (Exception ex)
            {
                return null;
            }

            return Result;
        }
    }
}
