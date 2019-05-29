﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using Markdig;


namespace IT_News.Controllers
{
    public class HomeController : Controller
    {
        private IService<NewsDTO> newsService;
        public HomeController(IService<NewsDTO> newsService)
        {
            this.newsService = newsService;
        }
        public ActionResult Index()
        {
            StartPageView show = null;
            var newsDto = newsService.GetAll().ToList().LastOrDefault();
            if (newsDto != null)
            {
                var newsViewModel = Mapper.Map<NewsDTO, NewsViewModel>(newsDto);
                var tagsDto = newsService.GetAllTags().ToList();
                var tagsViewModel = Mapper.Map<IEnumerable<TagDTO>, IEnumerable<TagViewModel>>(tagsDto).ToList();
                show = new StartPageView
                {
                    NewsViewModels = newsViewModel,
                    TagViewModel = tagsViewModel
                };
                ViewData["TagCloud"] = GetTagClouds();

                var html = Markdown.ToHtml(newsViewModel.Text);
                ViewData["Mark"] = html;
            }
            return View(show);
        }
        public IEnumerable<TagCloud> GetTagClouds()
        {
            var totalNews = newsService.GetAll().Count();
            var tags = newsService.GetAllTags().ToList();
            return (from c in tags
                    orderby c.Name
                    select new TagCloud
                    {
                        Id = c.Id,
                        Name = c.Name,
                        CountOfTag = c.News.Count,
                        TotalNews = totalNews,
                    });
        }

        public static string GetTagClass(int tag, int news, string name)
        {
            var result = (tag * 100) / news;//процент содержания новостей в каждом теге
            if (result <= 1)
                return "tag1";
            if (result <= 2)
                return "tag2";
            if (result <= 4)
                return "tag3";
            if (result <= 8)
                return "tag4";
            if (result <= 12)
                return "tag5";
            if (result <= 18)
                return "tag6";
            if (result <= 30)
                return "tag7";
            return result <= 50 ? "tag8" : "tag9";
        }
    }
}