using AutoMapper;
using backendapi.Core.Dtos.Applicant;
using backendapi.Core.Dtos.Category;
using backendapi.Core.Dtos.Policy;
using backendapi.Core.Entities;

namespace backendapi.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            // Category
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryGetDto>();

            // Policy
            CreateMap<PolicyCreateDto, Policy>();
            CreateMap<Policy, PolicyGetDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            // Applicant
            CreateMap<ApplicantCreateDto, Applicant>();
            CreateMap<Applicant, ApplicantGetDto>()
                .ForMember(dest => dest.PolicyTitle, opt => opt.MapFrom(src => src.Policy.Title));
        }
    }
}
