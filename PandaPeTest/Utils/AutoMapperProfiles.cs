using AutoMapper;
using PandaPeTest.Api.Domain.DTO;
using PandaPeTest.Api.Domain.Entities;

namespace PandaPeTest.Api.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Candidates, CandidatesDTO>().ReverseMap();
            CreateMap<CandidatesDTO, Candidates>();

            CreateMap<CandidateExperiences, CandidateExperiencesDTO>().ReverseMap();
            CreateMap<CandidateExperiencesDTO, CandidateExperiences>();
        }
    }
}
