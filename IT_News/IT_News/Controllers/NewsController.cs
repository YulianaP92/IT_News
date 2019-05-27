using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using IT_News.Models;
using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using IT_News_DAL.Entities;
using Markdig;
using Microsoft.AspNet.Identity;

namespace IT_News.Controllers
{
    [Authorize(Roles = "admin,writer")]
    public class NewsController : Controller
    {
        private IService<NewsDTO> newsService;
        public NewsController(IService<NewsDTO> newsService)
        {
            this.newsService = newsService;
        }
        //public ActionResult MyNewsList()
        //{
        //    var news = newsService.GetAll();
        //    var result = Mapper.Map<IEnumerable<NewsDTO>, IEnumerable<NewsViewModel>>(news);
        //    return View(result);
        //    //return RedirectToAction("Index", "Home");
        //}
        //public ActionResult GetAllNews()
        //{
        //    var news = newsService.GetAll();
        //    var result = Mapper.Map<IEnumerable<NewsDTO>, IEnumerable<NewsViewModel>>(news);
        //    return View(result);
        //}
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

                var currentUserId = User.Identity.GetUserId();
                var allUsers= newsService.GetAllUsers();
                var getUser = allUsers.FirstOrDefault(x=>x.UserId== currentUserId);

                news.PostedOn = DateTime.Now;
                var newsDto = Mapper.Map<NewsDTO>(news);               
                newsDto.Tags.Clear();
                newsDto.Section = selectedSection;

                newsDto.UserPage = getUser;

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
        [HttpGet]
        public ActionResult EditNews(int id)
        {
            var newsDto = newsService.Get(id);
            if (newsDto == null)
                return HttpNotFound();
            var allSections = newsService.GetAllSections();
            var result = Mapper.Map<List<SectionViewModel>>(allSections);
            //var html = Markdown.ToHtml(newsDto.Text);
            //ViewData["Mark"] = html;
            var html = newsDto.Text;
            ViewData["Mark"] = html;
            SelectList sections = new SelectList(result, "Id", "Name");
            ViewBag.Sections = sections;
            var newsViewModel = Mapper.Map<NewsViewModel>(newsDto);
            return View(newsViewModel);
        }
        [HttpPost]
        public ActionResult EditNews(NewsViewModel newsViewModel)
        {
           var news= Mapper.Map<NewsDTO>(newsViewModel);
            var allSections = newsService.GetAllSections();
            var selectedSection = allSections.FirstOrDefault(x => x.Id == newsViewModel.SectionId);
            news.Section = selectedSection;
            newsService.Update(news);
            return RedirectToAction("Index","Home");
        }

        public ViewResult Details(int id)
        {
            var newsDTO = newsService.Get(id);
            var newsViewModel = Mapper.Map<NewsViewModel>(newsDTO);
            return View(newsViewModel);
        }
       
    }
}