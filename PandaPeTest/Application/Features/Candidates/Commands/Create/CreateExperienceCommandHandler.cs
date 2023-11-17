using AutoMapper;
using MediatR;
using PandaPeTest.Api.Domain.Interfaces;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Create
{
    public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, int>
    {
        private readonly IApplicationRepository<PandaPeTest.Api.Domain.Entities.CandidateExperiences> _ExperienceRepository;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly IMediator _Mediator;

        public CreateExperienceCommandHandler(IApplicationRepository<Domain.Entities.CandidateExperiences> experienceRepository,
                                             IUnitOfWork unitOfWork,
                                             IMapper mapper,
                                             IMediator mediator)
        {
            _ExperienceRepository = experienceRepository;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _Mediator = mediator;
        }

        public async Task<int> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
        {
            int Result = 0;
            try
            {
                var Experience = _Mapper.Map<PandaPeTest.Api.Domain.Entities.CandidateExperiences>(request.Request);
                await _ExperienceRepository.AddAsync(Experience, cancellationToken);
                await _UnitOfWork.SaveChangesAsync(cancellationToken);
                Result = Experience.IdCandidateExperience;
            }
            catch (Exception ex)
            {
                Result = 0;
            }
            return Result;
        }
    }
}
