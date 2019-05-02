using IT_News_BLL.DTO;
using IT_News_DAL.Entities;
using Profile = AutoMapper.Profile;

namespace IT_News_BLL.Infrastructure.MappingProfiles
{
    public class NewsMappingProfile:Profile
    {
        public NewsMappingProfile()
        {
            MapNewsToNewsDTO();
            MapNewsDTOToNews();
        }
        private void MapNewsToNewsDTO()
        {
            CreateMap<News, NewsDTO>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.ShortDescription, c => c.MapFrom(src => src.ShortDescription))
                .ForMember(dest => dest.Published, c => c.MapFrom(src => src.Published))
                .ForMember(dest => dest.PostedOn, c => c.MapFrom(src => src.PostedOn))
                .ForMember(dest => dest.Modified, c => c.MapFrom(src => src.Modified))
                .ForMember(dest => dest.Modified, c => c.MapFrom(src => src.Modified))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapNewsDTOToNews()
        {
            CreateMap<NewsDTO, News>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.ShortDescription, c => c.MapFrom(src => src.ShortDescription))
                .ForMember(dest => dest.Published, c => c.MapFrom(src => src.Published))
                .ForMember(dest => dest.PostedOn, c => c.MapFrom(src => src.PostedOn))
                .ForMember(dest => dest.Modified, c => c.MapFrom(src => src.Modified))
                .ForMember(dest => dest.Modified, c => c.MapFrom(src => src.Modified))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}