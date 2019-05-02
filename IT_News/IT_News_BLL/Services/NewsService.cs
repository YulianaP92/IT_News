using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using IT_News_DAL.Entities;
using IT_News_DAL.Repositories;

namespace IT_News_BLL.Services
{
    public class NewsService : INewsService
    {
        EFUnitOfWork Database { get; set; }

        public NewsService(EFUnitOfWork database)
        {
            this.Database = database;
        }
        public void Create(NewsDTO newsDto)
        {
            var newsDAL = new News()
            {
                Id = newsDto.Id,
                Modified = newsDto.Modified,
                PostedOn = newsDto.PostedOn,
                Published = newsDto.Published,
                ShortDescription = newsDto.ShortDescription,
                Title = newsDto.Title
            };
           Database.News.Create(newsDAL);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public NewsDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NewsDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(NewsDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
