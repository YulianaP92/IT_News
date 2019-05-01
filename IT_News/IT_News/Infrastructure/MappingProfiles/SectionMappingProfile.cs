using IT_News_BLL.DTO;
using IT_News_DAL.Entities;
using Profile = AutoMapper.Profile;
namespace IT_News.Infrastructure.MappingProfiles
{
    public class SectionMappingProfile:Profile
    {
        public SectionMappingProfile()
        {
            MapSectionToSectionDTO();
            MapSectionDTOToSection();
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