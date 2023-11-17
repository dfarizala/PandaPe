using AutoMapper;
using MediatR;
using PandaPeTest.Api.Domain.Interfaces;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Update
{
    public class UpdateExperienceCommandHandler : IRequestHandler<UpdateExperienceCommand, int>
    {
        private readonly IApplicationRepository<PandaPeTest.Api.Domain.Entities.CandidateExperiences> _ExperienceRepository;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly IMediator _Mediator;

        public UpdateExperienceCommandHandler(IApplicationRepository<Domain.Entities.CandidateExperiences> experienceRepository,
                                             IUnitOfWork unitOfWork,
                                             IMapper mapper,
                                             IMediator mediator)
        {
            _ExperienceRepository = experienceRepository;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _Mediator = mediator;
        }

        public async Task<int> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
        {
            int Result = 0;
            try
            { 
                var Experience = await _ExperienceRepository.GetAsync(x => x.IdCandidateExperience == request.Request.IdCandidateExperience);
                var ExperienceObj = Experience.ToList()[0];

                ExperienceObj.Company = request.Request.Company;
                ExperienceObj.Job = request.Request.Job;
                ExperienceObj.Description = request.Request.Description;
                ExperienceObj.Salary = request.Request.Salary;
                ExperienceObj.BeginDate = request.Request.BeginDate;
                ExperienceObj.EndDate = request.Request.EndDate;
                ExperienceObj.InsertDate = request.Request.InsertDate; 
                ExperienceObj.ModifyDate = request.Request.ModifyDate;

                await _ExperienceRepository.UpdateAsync(ExperienceObj, cancellationToken);
                await _UnitOfWork.SaveChangesAsync(cancellationToken);
                Result = 1;
            }
            catch (Exception ex)
            {
                Result = 0;
            }
            return Result;
        }
    }
}
