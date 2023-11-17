using MediatR;
using PandaPeTest.Api.Domain.Entities;
using PandaPeTest.Api.Domain.Interfaces;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Delete
{
    public class DeleteExperienceCommandHandler : IRequestHandler<DeleteCandidateCommand, bool>
    {
        private readonly IApplicationRepository<PandaPeTest.Api.Domain.Entities.CandidateExperiences> _ExperienceRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public DeleteExperienceCommandHandler(IApplicationRepository<CandidateExperiences> experienceRepository,
                                              IUnitOfWork unitOfWork)
        {
            _ExperienceRepository = experienceRepository;
            _UnitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            bool Result = false;
            try
            {
                var Experience = await _ExperienceRepository.GetAsync(x => x.IdCandidate == request.IdCandidate);
                var ExperienceObj = Experience.ToList();
                foreach (var experience in ExperienceObj)
                {
                    await _ExperienceRepository.DeleteAsync(experience, cancellationToken);
                }

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