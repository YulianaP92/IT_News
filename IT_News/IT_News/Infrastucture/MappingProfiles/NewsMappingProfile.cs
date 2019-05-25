using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_DAL.Entities;
using Profile = AutoMapper.Profile;

namespace IT_News.Infrastucture.MappingProfiles
{
    public class NewsMappingProfile:Profile
    {
        private CommentMappingProfile commentMappingProfile;
        private SectionMappingProfile sectionMappingProfile;
        private TagMappingProfile tagMappingProfile;
        private UserPageMappingProfile userPageMappingProfile;
        public NewsMappingProfile()
        {
            MapNewsViewModelToNewsDTO();
            MapNewsDTOToNewsViewModel();
            MapNewsToNewsDTO();
            MapNewsDTOToNews();
            commentMappingProfile=new CommentMappingProfile();
            sectionMappingProfile=new SectionMappingProfile();
            tagMappingProfile=new TagMappingProfile();
            userPageMappingProfile=new UserPageMappingProfile();
        }
        private void MapNewsViewModelToNewsDTO()
        {
            CreateMap<NewsViewModel, NewsDTO>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.ShortDescription, c => c.MapFrom(src => src.ShortDescription))
                .ForMember(dest => dest.Published, c => c.MapFrom(src => src.Published))
                .ForMember(dest => dest.PostedOn, c => c.MapFrom(src => src.PostedOn))
                .ForMember(dest => dest.Modified, c => c.MapFrom(src => src.Modified))
                .ForMember(dest => dest.Section, c => c.MapFrom(src => src.Section))
                .ForMember(dest => dest.Tags, c => c.MapFrom(src => src.Tags))
                .ForMember(dest => dest.Comments, c => c.MapFrom(src => src.Comments))
                .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Text))
                .ForMember(dest => dest.UserPage, c => c.MapFrom(src => src.UserPage))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapNewsDTOToNewsViewModel()
        {
            CreateMap<NewsDTO, NewsViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, c => c.MapFrom(src => src.Title))
                .ForMember(dest => dest.ShortDescription, c => c.MapFrom(src => src.ShortDescription))
                .ForMember(dest => dest.Published, c => c.MapFrom(src => src.Published))
                .ForMember(dest => dest.PostedOn, c => c.MapFrom(src => src.PostedOn))
                .ForMember(dest => dest.Modified, c => c.MapFrom(src => src.Modified))
                .ForMember(dest => dest.Section, c => c.MapFrom(src => src.Section))
                .ForMember(dest => dest.Tags, c => c.MapFrom(src => src.Tags))
                .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Text))
                .ForMember(dest => dest.Comments, c => c.MapFrom(src => src.Comments))
                .ForMember(dest => dest.UserPage, c => c.MapFrom(src => src.UserPage))
                .ForAllOtherMembers(c => c.Ignore());
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
                .ForMember(dest => dest.Section, c => c.MapFrom(src => src.Section))
                .ForMember(dest => dest.Tags, c => c.MapFrom(src => src.Tags))
                .ForMember(dest => dest.Comments, c => c.MapFrom(src => src.Comments))
                .ForMember(dest => dest.UserPage, c => c.MapFrom(src => src.UserPage))
                .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Text))
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
                .ForMember(dest => dest.Section, c => c.MapFrom(src => src.Section))
                .ForMember(dest => dest.Tags, c => c.MapFrom(src => src.Tags))
                .ForMember(dest => dest.Comments, c => c.MapFrom(src => src.Comments))
                .ForMember(dest => dest.UserPage, c => c.MapFrom(src => src.UserPage))
                .ForMember(dest => dest.Text, c => c.MapFrom(src => src.Text))
                .ForAllOtherMembers(c => c.Ignore());
        }

    }
}