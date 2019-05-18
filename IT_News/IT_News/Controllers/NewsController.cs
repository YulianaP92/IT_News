using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
                var tags = Mapper.Map<List<TagDTO>>(news.Tags);

                var allSections = newsService.GetAllSections();
                var selectedSection = allSections.FirstOrDefault(x => x.Id == news.SectionId);
                news.PostedOn = DateTime.Now;
                var newsDto = Mapper.Map<NewsDTO>(news);
                newsDto.Tags.Clear();
                newsDto.Section = selectedSection;
                newsService.Create(newsDto, tags);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            string shortPath = null;
            if (file != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(file.FileName);
                // сохраняем файл в папку Files в проекте
                shortPath = "/Files/" + fileName;
                var path = Server.MapPath(shortPath);
                file.SaveAs(path);
            }

            var result = new {filename = shortPath };
            return Json(result);
        }

    }
}