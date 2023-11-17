using AutoMapper;
using MediatR;
using PandaPeTest.Api.Application.Features.Candidates.Commands.Create;
using PandaPeTest.Api.Domain.Entities;
using PandaPeTest.Api.Domain.Interfaces;
using System.Data;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Delete
{
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, bool>
    {
        private readonly IApplicationRepository<PandaPeTest.Api.Domain.Entities.Candidates> _CandidatesRepository;
        private readonly IApplicationRepository<PandaPeTest.Api.Domain.Entities.CandidateExperiences> _ExperienceRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public DeleteCandidateCommandHandler(IApplicationRepository<Domain.Entities.Candidates> candidatesRepository, 
                                             IApplicationRepository<CandidateExperiences> experienceRepository, 
                                             IUnitOfWork unitOfWork)
        {
            _CandidatesRepository = candidatesRepository;
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
                foreach(var experience in ExperienceObj) 
                {
                    await _ExperienceRepository.DeleteAsync(experience, cancellationToken);
                }

                var Candidate = await _CandidatesRepository.GetAsync(x => x.IdCandidate == request.IdCandidate);
                var CandidateObj = Candidate.ToList();
                await _CandidatesRepository.DeleteAsync(CandidateObj[0], cancellationToken);
                
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
