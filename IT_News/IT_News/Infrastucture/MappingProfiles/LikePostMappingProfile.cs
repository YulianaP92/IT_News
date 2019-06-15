﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_DAL.Entities;

namespace IT_News.Infrastucture.MappingProfiles
{
    public class LikePostMappingProfile:Profile
    {
        public LikePostMappingProfile()
        {
            MapLikeToLiketDTO();
            MapLiketDTOToLike();
        }
      
        private void MapLikeToLiketDTO()
        {
            CreateMap<LikePost, LikePostDto>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.CommentId, c => c.MapFrom(src => src.CommentId))
                .ForMember(dest => dest.CommentId, c => c.MapFrom(src => src.CommentId))
                .ForMember(dest => dest.Like, c => c.MapFrom(src => src.Like))
                .ForMember(dest => dest.NewsId, c => c.MapFrom(src => src.NewsId))
                .ForMember(dest => dest.User, c => c.MapFrom(src => src.User))
                .ForAllOtherMembers(c => c.Ignore());
        }
        private void MapLiketDTOToLike()
        {
            CreateMap<LikePostDto, LikePost>()
                .ForMember(dest => dest.Id, c => c.MapFrom(src => src.Id))
                .ForMember(dest => dest.CommentId, c => c.MapFrom(src => src.CommentId))
                .ForMember(dest => dest.CommentId, c => c.MapFrom(src => src.CommentId))
                .ForMember(dest => dest.Like, c => c.MapFrom(src => src.Like))
                .ForMember(dest => dest.NewsId, c => c.MapFrom(src => src.NewsId))
                .ForMember(dest => dest.User, c => c.MapFrom(src => src.User))
                .ForAllOtherMembers(c => c.Ignore());
        }
    }
}