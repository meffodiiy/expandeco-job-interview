using AutoMapper;
using Expandeco.JobInterview.Data;
using Expandeco.JobInterview.Data.DTO;

namespace Expandeco.JobInterview.Services
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Translation, TranslationUpdateDto>().ReverseMap();
        }
    }
}
