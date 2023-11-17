using MediatR;
using PandaPeTest.Api.Domain.Interfaces;
using PandaPeTest.Api.Domain.Entities;
using AutoMapper;

namespace PandaPeTest.Api.Application.Features.Candidates.Commands.Create
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
    {
        private readonly IApplicationRepository<PandaPeTest.Api.Domain.Entities.Candidates> _CandidatesRepository;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly IMediator _Mediator;

        public CreateCandidateCommandHandler(IApplicationRepository<Domain.Entities.Candidates> candidatesRepository,
                                             IUnitOfWork unitOfWork,
                                             IMapper mapper,
                                             IMediator mediator)
        {
            _CandidatesRepository = candidatesRepository;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _Mediator = mediator;
        }

        public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            int Result = 0;
            try
            {
                var Candidate = _Mapper.Map<PandaPeTest.Api.Domain.Entities.Candidates>(request.Request);
                await _CandidatesRepository.AddAsync(Candidate, cancellationToken);
                await _UnitOfWork.SaveChangesAsync(cancellationToken);
                Result = Candidate.IdCandidate;
            }
            catch (Exception ex)
            {
                Result = 0;
            }
            return Result;
        }
    }
}
