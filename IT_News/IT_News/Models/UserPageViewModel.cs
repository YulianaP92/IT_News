﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IT_News.Models.News;
using IT_News_BLL.DTO;

namespace IT_News.Models
{
    public class UserPageViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual List<NewsViewModel> News { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        
    }
}