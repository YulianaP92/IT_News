﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
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
                var allUsers = newsService.GetAllUsers();
                var getUser = allUsers.FirstOrDefault(x => x.UserId == currentUserId);

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
        public ActionResult Upload(HttpPostedFileBase file) //сохранение картинки на сервер в markdown
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
            var result = new { filename = shortPath };
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
            var news = Mapper.Map<NewsDTO>(newsViewModel);
            //var allSections = newsService.GetAllSections(); // SectionId
            //var selectedSection = allSections.FirstOrDefault(x => x.Id == newsViewModel.SectionId);
            //news.Section = selectedSection;
            newsService.Update(news);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Details(int id)
        {
            var newsDTO = newsService.Get(id);
            var newsViewModel = Mapper.Map<NewsViewModel>(newsDTO);
            var html = Markdown.ToHtml(newsViewModel.Text);
            ViewData["Mark"] = html;
            return PartialView("Details",newsViewModel);
        }
        public ActionResult Delete(int id)
        {
            var newsDto = newsService.Get(id);
            if (newsDto == null)
                return HttpNotFound();
            newsService.Delete(id);
            return RedirectToAction("Index","Page");
        }   
        [HttpPost]
        public ActionResult Comment(int id, string comments1)
        {
            var newsDto = newsService.Get(id);
            if (newsDto == null)
                return HttpNotFound();
            var commentViewModel = new CommentViewModel(){Date = DateTime.Now,Description = comments1};

            var commentDto = Mapper.Map<CommentDTO>(commentViewModel);
            commentDto.NewsId = id;
            newsService.Create(commentDto);
            //newsDto.Comments.Add(commentDto);
            return RedirectToAction("Index", "Home");
        }

    }
}