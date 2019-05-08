using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using IT_News_DAL.Entities;

namespace IT_News.Controllers
{
    public class NewsController : Controller
    {
        private INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }
        //    public ActionResult Index()
        //    {
        //        var news = newsService.GetAll();
        //        var result = Mapper.Map<IEnumerable<NewsDTO>, IEnumerable<NewsViewModel>>(news);
        //        return View(result);
        //        //return RedirectToAction("Index", "Home");
        //    }
        //    //public ActionResult GetAllNews()
        //    //{
        //    //    var news = newsService.GetAll();
        //    //    var result = Mapper.Map<IEnumerable<NewsDTO>, IEnumerable<NewsViewModel>>(news);
        //    //    return View(result);
        //    //}

        [HttpGet]
        public ActionResult CreateNews()
        {
            var allSections = newsService.GetAllSections();
            var result = Mapper.Map<List<SectionViewModel>>(allSections);
            SelectList sections = new SelectList(result, "Id", "Name");
            ViewBag.Sections = sections;
            return View();
        }
        [HttpPost]
        public ActionResult CreateNews(NewsViewModel news)
        {
            if (news != null)
            {
                news.PostedOn = DateTime.Now;
                var result = Mapper.Map<NewsDTO>(news);
                newsService.Create(result);                
            }
            return RedirectToAction("Index", "Home");
        }
    }
}