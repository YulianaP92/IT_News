﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IT_News.Models;
using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using IT_News_DAL.EF;
using IT_News_DAL.Entities;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR.Hubs;
using Ninject;

namespace IT_News.Hubs
{
    [HubName("commentHub")]
    public class CommentHub : Hub
    {
        private IService<NewsDTO> newsService;
        private IService<UserPageDTO> pageService;

        public CommentHub()
        {
            this.newsService = DependencyResolver.Current.GetService<IService<NewsDTO>>();
            this.pageService = DependencyResolver.Current.GetService<IService<UserPageDTO>>();
        }

        public void Comments(string modelId, string comments1, string userPageId, string Rating)
        {
            var id = int.Parse(modelId);
            var newsDto = newsService.Get(id);
            var commentDto = new CommentDTO
            {
                Date = DateTime.Now,
                Description = comments1,
                NewsId = id
            };
            var userDto = pageService.Get(int.Parse(userPageId));
            commentDto.AuthorId = userDto.Id;
            commentDto.AuthorName = userDto.Name;
            commentDto.Rating = Int32.Parse(Rating);
            newsService.Create(commentDto);
            newsDto.Comments.Add(commentDto);

            Clients.All.Send(commentDto.Description, userDto.Name, commentDto.Date.ToString("dd.MM.yyyy"), commentDto.Rating);
        }

        public decimal TotalRating(string modelId)
        {
            var id = int.Parse(modelId);
            var newsDto = newsService.Get(id);
            var ratings = newsDto.Comments.ToList();
            decimal totalRating;
            if (ratings.Count > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rating);
                var ratingCount = ratings.Count;
                decimal rating = 0;
                if (ratingCount > 0)
                {
                    rating = (ratingSum / ratingCount);
                }
                totalRating = decimal.Parse(rating.ToString());
            }
            else
            {
                totalRating = 0;
            }
           
            return totalRating;

        }

        public void Show(string total,string modelId)
        {
            var totalDecimal = TotalRating(modelId);
            Clients.All.TotalRatingSend(totalDecimal);
        }
    }
}