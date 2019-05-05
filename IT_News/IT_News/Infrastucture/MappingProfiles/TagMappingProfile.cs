using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_DAL.Entities;
using Profile = AutoMapper.Profile;

namespace IT_News.Infrastucture.MappingProfiles
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            MapTagViewModelToTagDTO();
            MapTagViewModelDTOToTag();
            MapTagToTagDTO();
            MapTagDTOToTag();
        }
        private void MapTagViewModelToTagDTO()
        {
            CreateMap<TagViewModel, TagDTO>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapTagViewModelDTOToTag()
        {
            CreateMap<TagDTO, TagViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForAllOtherMembers(c => c.Ignore());
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