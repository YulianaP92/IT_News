using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_DAL.Entities;
using Profile = AutoMapper.Profile;
namespace IT_News.Infrastucture.MappingProfiles
{
    public class SectionMappingProfile:Profile
    {
        public SectionMappingProfile()
        {
            MapSectionViewModelToSectionDTO();
            MapSectionDTOToSectionViewModel();
            MapSectionToSectionDTO();
            MapSectionDTOToSection();
        }
        private void MapSectionViewModelToSectionDTO()
        {
            CreateMap<SectionViewModel, SectionDTO>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapSectionDTOToSectionViewModel()
        {
            CreateMap<SectionDTO, SectionViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name))
                .ForAllOtherMembers(c => c.Ignore());
        }

        private void MapSectionToSectionDTO()
        {
            CreateMap<Section, SectionDTO>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapSectionDTOToSection()
        {
            CreateMap<SectionDTO, Section>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}