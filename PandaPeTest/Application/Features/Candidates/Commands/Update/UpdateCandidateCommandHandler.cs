using MediatR;
using PandaPeTest.Api.Domain.Interfaces;
using PandaPeTest.Api.Domain.Entities;
using AutoMapper;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Update
{
    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, int>
    {
        private readonly IApplicationRepository<PandaPeTest.Api.Domain.Entities.Candidates> _CandidatesRepository;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly IMediator _Mediator;

        public UpdateCandidateCommandHandler(IApplicationRepository<Domain.Entities.Candidates> candidatesRepository,
                                             IUnitOfWork unitOfWork,
                                             IMapper mapper,
                                             IMediator mediator)
        {
            _CandidatesRepository = candidatesRepository;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _Mediator = mediator;
        }

        public async Task<int> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            int Result = 0;
            try
            {
                var Candidate = await _CandidatesRepository.GetAsync(x => x.IdCandidate == request.Request.IdCandidate);
                var CandidateObj = Candidate.ToList()[0];

                CandidateObj.BirthDate = request.Request.BirthDate;
                CandidateObj.ModifyDate = request.Request.ModifyDate;
                CandidateObj.InsertDate = request.Request.InsertDate;
                CandidateObj.SurName = request.Request.SurName;
                CandidateObj.Name = request.Request.Name;
                CandidateObj.Email = request.Request.Email;

                await _CandidatesRepository.UpdateAsync(CandidateObj, cancellationToken);
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
