using AutoMapper;
using MediatR;
using PandaPeTest.Api.Domain.DTO;
using PandaPeTest.Api.Domain.Interfaces;

namespace PandaPeTest.Api.Application.Features.Candidates.Queries.Get
{
    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, List<CandidatesDTO>>
    {
        private readonly IApplicationRepository<PandaPeTest.Api.Domain.Entities.Candidates> _CandidatesRepository;
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly IMediator _Mediator;

        public GetCandidatesQueryHandler(IApplicationRepository<Domain.Entities.Candidates> candidatesRepository, 
                                           IUnitOfWork unitOfWork, 
                                           IMapper mapper, 
                                           IMediator mediator)
        {
            _CandidatesRepository = candidatesRepository;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _Mediator = mediator;
        }

        public async Task<List<CandidatesDTO>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {
            List<CandidatesDTO> Result = new();
            try 
            {
                var Candidates = await _CandidatesRepository.GetAsync();
                foreach (var Candidate in Candidates) 
                {
                    var CandidateObj = _Mapper.Map<CandidatesDTO>(Candidate);
                    Result.Add(CandidateObj);
                }
            }
            catch(Exception ex)
            {
                return null;
            }

            return Result;
        }
    }
}
