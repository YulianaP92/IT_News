using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IT_News.Models;
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
        public ActionResult Index(string page)
        {
            UserPageViewModel userPageViewModel = null;
            if (page!=null)
            {
               
                var currentUserId = User.Identity.GetUserId();
                if (currentUserId == page)
                {
                    var userPageDto = pageService.Get(page);
                    if (userPageDto != null)
                    {
                        userPageViewModel = Mapper.Map<UserPageViewModel>(userPageDto);
                    }
                }
            }
            else
            {
                return RedirectToAction("Index","Home");
            }

            return View(userPageViewModel);
        }
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
            return RedirectToAction("Index", "Home");
        }
    }
}