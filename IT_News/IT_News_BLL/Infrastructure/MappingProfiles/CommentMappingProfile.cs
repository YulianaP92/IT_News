//using IT_News_BLL.DTO;
//using IT_News_DAL.Entities;
//using Profile = AutoMapper.Profile;

//namespace IT_News_BLL.Infrastructure.MappingProfiles
//{
//    public class CommentMappingProfile: Profile
//    {
//        public CommentMappingProfile()
//        {
//            MapCommentToCommentDTO();
//            MapCommentDTOToComment();
//        }
//        private void MapCommentToCommentDTO()
//        {
//            CreateMap<Comment, CommentDTO>()
//                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
//                .ForMember(dest => dest.Date, c => c.MapFrom(src => src.Date))
//                .ForMember(dest => dest.CommentId, c => c.MapFrom(src => src.CommentId))
//                .ForMember(dest => dest.AuthorDtoId, c => c.MapFrom(src => src.AuthorId))
//                .ForMember(dest => dest.NewsDtoId, c => c.MapFrom(src => src.News))
//                .ForAllOtherMembers(c => c.Ignore());
//        }
//        private void MapCommentDTOToComment()
//        {
//            CreateMap<CommentDTO, Comment>()
//                .ForMember(dest => dest.Description, c => c.MapFrom(src => src.Description))
//                .ForMember(dest => dest.Date, c => c.MapFrom(src => src.Date))
//                .ForMember(dest => dest.CommentId, c => c.MapFrom(src => src.CommentId))
//                .ForMember(dest => dest.AuthorId, c => c.MapFrom(src => src.AuthorDtoId))
//                .ForMember(dest => dest.News, c => c.MapFrom(src => src.NewsDtoId))
//                .ForAllOtherMembers(c => c.Ignore());
//        }

//    }
//}