using MediatR;
using PandaPeTest.Api.Domain.Entities;
using PandaPeTest.Api.Domain.Interfaces;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Delete
{
    public class DeleteExperienceByIdCommandHandler : IRequestHandler<DeleteExperienceByIdCommand, bool>
    {
        private readonly IApplicationRepository<PandaPeTest.Api.Domain.Entities.CandidateExperiences> _ExperienceRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public DeleteExperienceByIdCommandHandler(IApplicationRepository<CandidateExperiences> experienceRepository,
                                                  IUnitOfWork unitOfWork)
        {
            _ExperienceRepository = experienceRepository;
            _UnitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteExperienceByIdCommand request, CancellationToken cancellationToken)
        {
            bool Result = false;
            try
            {
                var Experience = await _ExperienceRepository.GetAsync(x => x.IdCandidateExperience == request.ExperienceId);
                var ExperienceObj = Experience.ToList();
                await _ExperienceRepository.DeleteAsync(ExperienceObj[0], cancellationToken);
                
                await _UnitOfWork.SaveChangesAsync(cancellationToken);

                Result = true;
            }
            catch (Exception ex)
            {
                Result = false;
            }
            return Result;
        }
    }
}
