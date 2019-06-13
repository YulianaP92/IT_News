using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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
        private IService<NewsDTO> newsService;
        public HomeController(IService<NewsDTO> newsService)
        {
            this.newsService = newsService;
        }
        public ActionResult Index()
        {
            StartPageView show = null;
            var newsDtoList = newsService.GetAll().ToList();
            if (newsDtoList != null)
            {

                var allNewsIndexRating = newsDtoList.OrderByDescending(s => s.TotalRating).Take(5).ToList();
                var newsViewModelRating= Mapper.Map<List<NewsDTO>, List<NewsViewModel>>(allNewsIndexRating);
                var allNewsIndex = newsDtoList.OrderByDescending(s => s.PostedOn).Take(5).ToList();              
                var newsViewModel = Mapper.Map<List<NewsDTO>, List<NewsViewModel>>(allNewsIndex);
                var tagsDto = newsService.GetAllTags().ToList();
                var tagsViewModel = Mapper.Map<IEnumerable<TagDTO>, List<TagViewModel>>(tagsDto);
                show = new StartPageView
                {
                    NewsViewModels = newsViewModel,
                    TagViewModel = tagsViewModel,
                    NewsViewModelsRating = newsViewModelRating
                };
                ViewData["TagCloud"] = GetTagClouds();
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
        //создать 1-ый метод: расчет веса тега, 2 метод: на основе веса тега вернуть css
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

        public ActionResult ChooseLang(string languageAbbrevation)
        {
            if (languageAbbrevation!=null)
            {
                //if (languageAbbrevation=="RU")
                //{
                //    languageAbbrevation = "EN";
                //}
                Thread.CurrentThread.CurrentCulture=CultureInfo.CreateSpecificCulture(languageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageAbbrevation);
            }
            HttpCookie cookie=new HttpCookie("Language");
            cookie.Value = languageAbbrevation;
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Home");
        }
    }
}