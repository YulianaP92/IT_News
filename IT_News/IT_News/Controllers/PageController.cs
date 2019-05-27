﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IT_News.Models;
using IT_News.Models.News;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using IT_News_BLL.Services;
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
        //public ActionResult Index()
        //{
        //    UserPageViewModel userPageViewModel = null;
        //    var currentUserId = User.Identity.GetUserId();
        //    if (currentUserId != null)
        //    {
        //        var userPageDto = pageService.Get(currentUserId);
        //        if (userPageDto != null)
        //        {
        //            userPageViewModel = Mapper.Map<UserPageViewModel>(userPageDto);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View(userPageViewModel);
        //}
        
        public ActionResult Index(string sortOrder)
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
            else
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Title desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            var news = userPageViewModel.News;
            switch (sortOrder)
            {
                case "Title desc":
                    news = news.OrderByDescending(s => s.Title).ToList();
                    break;
                case "Date":
                    news = news.OrderBy(s => s.PostedOn).ToList();
                    break;
                case "Date desc":
                    news = news.OrderByDescending(s => s.PostedOn).ToList();
                    break;
                default:
                    news = news.OrderBy(s => s.PostedOn).ToList();
                    break;
            }
            //if (Request.IsAjaxRequest())
            //{
               
                userPageViewModel.News = news.ToList();
            //    return PartialView("MyNewsList", userPageViewModel);
            //}
            return View(userPageViewModel);
        }
        //[HttpPost]
        //public ActionResult MyNewsList(int id, string sortOrder)
        //{
        //    var userPageDto = pageService.Get(id);
        //    var userPageViewModel = Mapper.Map<UserPageViewModel>(userPageDto);
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Title desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
        //    var news = userPageViewModel.News;
        //    switch (sortOrder)
        //    {
        //        case "Title desc":
        //            news = news.OrderByDescending(s => s.Title).ToList();
        //            break;
        //        case "Date":
        //            news = news.OrderBy(s => s.PostedOn).ToList();
        //            break;
        //        case "Date desc":
        //            news = news.OrderByDescending(s => s.PostedOn).ToList();
        //            break;
        //        default:
        //            news = news.OrderBy(s => s.PostedOn).ToList();
        //            break;
        //    }
        //    userPageViewModel.News = news.ToList();
        //    return PartialView("MyNewsList", userPageViewModel);
        //}
        public ActionResult Create()
        {
            // var currentUserId = User.Identity.GetUserId();

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