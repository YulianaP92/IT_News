﻿using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using IT_News.Models;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using Microsoft.AspNet.Identity;

namespace IT_News.Controllers
{
    [Authorize(Roles = "admin,writer")]
    public class PageController : Controller
    {

        private IService<UserPageDTO> pageService;
        public PageController(IService<UserPageDTO> pageService)
        {
            this.pageService = pageService;
        }
        public UserPageViewModel CreateUserPageViewModel()
        //метод предназначен для избежания дублирования кода в методах Index(),Sort(string sortOrder),Search(string searchString)
        {
            UserPageViewModel userPageViewModel = null;
            var currentUserId = User.Identity.GetUserId();
            if (currentUserId != null)
            {
                var userPageDto = pageService.Get(currentUserId);
                if (userPageDto != null)
                {
                    userPageViewModel = Mapper.Map<UserPageViewModel>(userPageDto);
                }
            }
            return userPageViewModel;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userPageViewModel = CreateUserPageViewModel();

            if (userPageViewModel == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(userPageViewModel);
        }

        [HttpGet]
        public ActionResult SortTitle(string sortOrder)
        {
            var userPageViewModel = CreateUserPageViewModel();

            if (userPageViewModel == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Title desc" : "";
            var news = userPageViewModel.News;

            switch (sortOrder)
            {
                case "Title desc":
                    news = news.OrderByDescending(s => s.Title).ToList();
                    break;
                default:
                    news = news.OrderBy(s => s.Title).ToList();
                    break;
            }
            userPageViewModel.News = news.ToList();
            return PartialView("MyNewsList", userPageViewModel);
        }
        [HttpGet]
        public ActionResult SortDate(string sortOrder)
        {
            var userPageViewModel = CreateUserPageViewModel();

            if (userPageViewModel == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date desc" : null;
            var news = userPageViewModel.News;

            switch (sortOrder)
            {
                case "Date desc":
                    news = news.OrderByDescending(s => s.PostedOn).ToList();
                    break;
                default:
                    news = news.OrderBy(s => s.PostedOn).ToList();
                    break;
            }
            userPageViewModel.News = news.ToList();
            return PartialView("MyNewsList", userPageViewModel);
        }
        [HttpPost]
        public ActionResult Search(string searchString)
        {
            var userPageViewModel = CreateUserPageViewModel();

            if (userPageViewModel == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var news = userPageViewModel.News;
            if (!String.IsNullOrEmpty(searchString))
            {
                news = news.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper())
                                       || s.Section.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
            }
            userPageViewModel.News = news.ToList();
            return PartialView("MyNewsList", userPageViewModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserPageViewModel page)
        {
            if (page != null)
            {
                var currentUserId = User.Identity.GetUserId();
                page.UserId = currentUserId;
                var pageDto = Mapper.Map<UserPageDTO>(page);
                pageService.Create(pageDto);
            }
            return RedirectToAction("Index", "Page");
        }
    }
}