using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using IT_News.Models;
using IT_News_BLL.DTO;
using IT_News_DAL.Entities;

namespace IT_News.Infrastucture.MappingProfiles
{
    public class UserPageMappingProfile:Profile
    {
        public UserPageMappingProfile()
        {
            MapUserPageViewModelToUserPageDTO();
            MapUserPageDTOToUserPageViewModel();
            MapUserPageDTOToUserPageDAL();
            MapUserPageToUserPageDTO();
        }
        private void MapUserPageViewModelToUserPageDTO()
        {
            CreateMap<UserPageViewModel, UserPageDTO>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name))
                .ForMember(dest => dest.News, c => c.MapFrom(src => src.News))
                .ForMember(dest => dest.Age, c => c.MapFrom(src => src.Age))
                .ForMember(dest => dest.UserId, c => c.MapFrom(src => src.UserId))
                .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.LastName))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapUserPageDTOToUserPageViewModel()
        {
            CreateMap<UserPageDTO, UserPageViewModel>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name))
                .ForMember(dest => dest.News, c => c.MapFrom(src => src.News))
                .ForMember(dest => dest.Age, c => c.MapFrom(src => src.Age))
                .ForMember(dest => dest.UserId, c => c.MapFrom(src => src.UserId))
                .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.LastName))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapUserPageDTOToUserPageDAL()
        {
            CreateMap<UserPageDTO, UserPage>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name))
                .ForMember(dest => dest.News, c => c.MapFrom(src => src.News))
                .ForMember(dest => dest.Age, c => c.MapFrom(src => src.Age))
                .ForMember(dest => dest.UserId, c => c.MapFrom(src => src.UserId))
                .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.LastName))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapUserPageToUserPageDTO()
        {
            CreateMap<UserPage, UserPageDTO>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, c => c.MapFrom(src => src.Name))
                .ForMember(dest => dest.News, c => c.MapFrom(src => src.News))
                .ForMember(dest => dest.Age, c => c.MapFrom(src => src.Age))
                .ForMember(dest => dest.UserId, c => c.MapFrom(src => src.UserId))
                .ForMember(dest => dest.LastName, c => c.MapFrom(src => src.LastName))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}