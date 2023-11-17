using AutoMapper;
using MediatR;
using PandaPeTest.Api.Domain.DTO;
using PandaPeTest.Api.Domain.Interfaces;

namespace PandaPeTest.Api.Application.Features.Candidates.Queries.Get
{
    public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, GetCandidateByIdResponse>
    {
        private readonly IApplicationRepository<PandaPeTest.Api.Domain.Entities.Candidates> _CandidatesRepository;
        private readonly IApplicationRepository<PandaPeTest.Api.Domain.Entities.CandidateExperiences> _ExperienceRepository;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly IMediator _Mediator;

        public GetCandidateByIdQueryHandler(IApplicationRepository<Domain.Entities.Candidates> candidatesRepository,
                                           IUnitOfWork unitOfWork,
                                           IMapper mapper,
                                           IMediator mediator,
                                           IApplicationRepository<Domain.Entities.CandidateExperiences> experienceRepository)
        {
            _CandidatesRepository = candidatesRepository;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _Mediator = mediator;
            _ExperienceRepository = experienceRepository;
        }

        public async Task<GetCandidateByIdResponse> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            GetCandidateByIdResponse Result = new();
            try
            {
                var Candidates = await _CandidatesRepository.GetAsync(x => x.IdCandidate == request.CandidateId);
                Result.Candidate = _Mapper.Map<CandidatesDTO>(Candidates.ToList()[0]);

                List<CandidateExperiencesDTO> ExperienceList = new();

                var Experiences = await _ExperienceRepository.GetAsync(x => x.IdCandidate == request.CandidateId);
                foreach ( var experience in Experiences ) 
                {
                    ExperienceList.Add(_Mapper.Map<CandidateExperiencesDTO>(experience));
                }
                Result.Experiences = ExperienceList;
            }
            catch (Exception ex)
            {
                return null;
            }

            return Result;
        }
    }
}
