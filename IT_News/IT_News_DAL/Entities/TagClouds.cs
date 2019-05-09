using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_News_DAL.Entities
{
   public class TagClouds:Tag
    {
        public int CountOfTag { get; set; } //кол-во тегов
        public int TotalNews { get; set; } //кол-во новостей
    }
}
