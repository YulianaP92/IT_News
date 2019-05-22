using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using IT_News_BLL.Services;
using Microsoft.AspNet.Identity;

namespace IT_News.Controllers
{
    public class PageController : Controller
    {
        private IService<UserPageDTO> pageService;
        public PageController(IService<UserPageDTO> pageService)
        {
            this.pageService = pageService;
        }
        public ActionResult Index()
        {
           // var currentUserId = User.Identity.GetUserId();
           
            return View();
        }
    }
}