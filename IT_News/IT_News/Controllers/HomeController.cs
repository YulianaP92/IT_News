using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;

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
            var news = newsService.GetAll();
            var result = Mapper.Map<IEnumerable<NewsDTO>, IEnumerable<NewsViewModel>>(news);
            return View(result);
            //return RedirectToAction("Index", "Home");
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