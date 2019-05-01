using IT_News_BLL.DTO;
using IT_News_DAL.Entities;
using Profile = AutoMapper.Profile;

namespace IT_News.Infrastructure.MappingProfiles
{
    public class TagMappingProfile:Profile
    {
        public TagMappingProfile()
        {
            MapTagToTagDTO();
            MapTagDTOToTag();
        }
        private void MapTagToTagDTO()
        {
            CreateMap<Tag, TagDTO>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapTagDTOToTag()
        {
            CreateMap<TagDTO, Tag>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}