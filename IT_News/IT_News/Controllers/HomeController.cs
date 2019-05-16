using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using Markdig;
using Markdig.Syntax;


namespace IT_News.Controllers
{
    public class HomeController : Controller
    {
        private INewsService newsService;
        public HomeController(INewsService newsService)
        {
            this.newsService = newsService;
        }
        public ActionResult Index()
        {
            //var newsDto = newsService.GetAll().ToList();
            var newsDto = newsService.GetAll().ToList().LastOrDefault();

            //var newsViewModel = Mapper.Map<IEnumerable<NewsDTO>, IEnumerable<NewsViewModel>>(newsDto).ToList();
            var newsViewModel = Mapper.Map<NewsDTO, NewsViewModel>(newsDto);

            //newsViewModel.Text = 
            var tagsDto = newsService.GetAllTags().ToList();
            var tagsViewModel= Mapper.Map<IEnumerable<TagDTO>, IEnumerable<TagViewModel>>(tagsDto).ToList();
            var show = new StartPageView()
            {
                NewsViewModels = newsViewModel,
                TagViewModel = tagsViewModel
            };
            ViewData["TagCloud"] = GetTagClouds();
         
            ViewData["Mark"] = Markdown.ToHtml(@"![file](~/App_Data/Files/image-1558039166305.jpg)");

            return View(show);
            //return RedirectToAction("Index", "Home");
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}