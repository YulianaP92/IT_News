using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using IT_News_DAL.Entities;
using IT_News_DAL.Interfaces;

namespace IT_News_BLL.Services
{
    public class NewsService : INewsService
    {
        IUnitOfWork Database { get; set; }

        public NewsService(IUnitOfWork database)
        {
            this.Database = database;
        }
        public void Create(NewsDTO newsDto, List<TagDTO> tags)
        {
            var tagCollection = Mapper.Map<List<Tag>>(tags);
            var newsDal = Mapper.Map<News>(newsDto);
            Database.News.Create(newsDal, tagCollection);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.News.Delete(id);
            Database.Save();
        }

        public NewsDTO Get(int id)
        {
            var news = Database.News.Get(id);
            var result = Mapper.Map<NewsDTO>(news);
            return result;
        }

        public IEnumerable<NewsDTO> GetAll()
        {
            var allNews = Database.News.GetAll().ToList();
            var result = Mapper.Map<IEnumerable<NewsDTO>>(allNews);
            return result;
        }

        public void Update(NewsDTO item)
        {
            var newsDAL = Mapper.Map<News>(item);
            Database.News.Update(newsDAL);
            Database.Save();
        }

        public IEnumerable<SectionDTO> GetAllSections()
        {
            var allSections = Database.News.GetAllSections().ToList();
            var sectionDTO = Mapper.Map<IEnumerable<SectionDTO>>(allSections).ToList();
            return sectionDTO;
        }

        public IEnumerable<TagDTO> GetAllTags()
        {
            var allTags = Database.News.GetAllTags().ToList();
            var tagDto = Mapper.Map<IEnumerable<TagDTO>>(allTags).ToList();
            return tagDto;
        }
    }
}
