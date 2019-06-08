using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_DAL.Entities;
using Profile = AutoMapper.Profile;

namespace IT_News.Infrastucture.MappingProfiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            MapCommentViewModelToCommentDTO();
            MapCommentDTOToCommentViewModel();
            MapCommentToCommentDTO();
            MapCommentDTOToComment();
        }
        private void MapCommentViewModelToCommentDTO()
        {
            CreateMap<CommentViewModel, CommentDTO>()
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Date, c => c.MapFrom(src => src.Date))
                .ForMember(dest => dest.CommentId, c => c.MapFrom(src => src.CommentId))
                .ForMember(dest => dest.AuthorId, c => c.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.AuthorName, c => c.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.NewsDto, c => c.MapFrom(src => src.NewsViewModel))
                .ForMember(dest => dest.Rating, c => c.MapFrom(src => src.Rating))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapCommentDTOToCommentViewModel()
        {
            CreateMap<CommentDTO, CommentViewModel>()
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Date, c => c.MapFrom(src => src.Date))
                .ForMember(dest => dest.CommentId, c => c.MapFrom(src => src.CommentId))
                .ForMember(dest => dest.AuthorId, c => c.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.AuthorName, c => c.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.NewsViewModel, c => c.MapFrom(src => src.NewsDto))
                .ForMember(dest => dest.Rating, c => c.MapFrom(src => src.Rating))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapCommentToCommentDTO()
        {
            CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Date, c => c.MapFrom(src => src.Date))
                .ForMember(dest => dest.CommentId, c => c.MapFrom(src => src.CommentId))
                .ForMember(dest => dest.NewsDto, c => c.MapFrom(src => src.News))
                .ForMember(dest => dest.AuthorName, c => c.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.AuthorId, c => c.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.Rating, c => c.MapFrom(src => src.Rating))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapCommentDTOToComment()
        {
            CreateMap<CommentDTO, Comment>()
                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
                .ForMember(dest => dest.Date, c => c.MapFrom(src => src.Date))
                .ForMember(dest => dest.CommentId, c => c.MapFrom(src => src.CommentId))
                .ForMember(dest => dest.News, c => c.MapFrom(src => src.NewsDto))
                .ForMember(dest => dest.AuthorName, c => c.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.AuthorId, c => c.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.Rating, c => c.MapFrom(src => src.Rating))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}