using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using IT_News_DAL.Entities;
using IT_News_DAL.Interfaces;
using IT_News_DAL.Repositories;

namespace IT_News_BLL.Services
{
    public class NewsService : INewsService
    {
        IUnitOfWork Database { get; set; }

        public NewsService(IUnitOfWork database)
        {
            this.Database = database;
        }
        public void Create(NewsDTO newsDto)
        {
           // var sectionDAL = new Section()
           // {
           //     Id = newsDto.Section.Id,
           //     Name = newsDto.Section.Name
           // };
           // var tagsDAL = newsDto.Tags.Select(x => new Tag(){ Id = x.Id, Name = x.Name ,Description =x.Description}).ToList();
           // var commentsDAL = newsDto.Comments.Select(x => new Comment() { Description = x.Description,AuthorId =x.AuthorDtoId,
           //     CommentId = x.CommentId,Date =x.Date }).ToList();
           // var newsDAL = new News()
           // {
           //     Id = newsDto.Id,
           //     Modified = newsDto.Modified,
           //     PostedOn = newsDto.PostedOn,
           //     Published = newsDto.Published,
           //     ShortDescription = newsDto.ShortDescription,
           //     Title = newsDto.Title,
           //     Section = sectionDAL,
           //     Tags = tagsDAL,
           //     Comments = commentsDAL                
           // };
           //Database.News.Create(newsDAL);
           //Database.Save();

            var result = Mapper.Map<News>(newsDto);
            Database.News.Create(result);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.News.Delete(id);
            Database.Save();
        }

        public NewsDTO Get(int id)
        {

            //var news = Database.News.Get(id);
            //var tagsDto = news.Tags.Select(x => new TagDTO() { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
            //var sectionDto = new SectionDTO()
            //{
            //    Id = news.Section.Id,
            //    Name = news.Section.Name
            //};            

            //var commentsDto = news.Comments.Select(x => new CommentDTO()
            //{
            //    Description = x.Description,
            //    AuthorDtoId = x.AuthorId,
            //    CommentId = x.CommentId,
            //    Date = x.Date
            //}).ToList();
            //return new NewsDTO()
            //{
            //    Id = news.Id,
            //    Modified = news.Modified,
            //    PostedOn = news.PostedOn,
            //    Published = news.Published,
            //    Title = news.Title,
            //    ShortDescription = news.ShortDescription,
            //    Section = sectionDto,
            //    Comments = commentsDto,
            //    Tags = tagsDto,               
            //};
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
            var newsDAL = Mapper.Map<NewsDTO, News>(item);
            Database.News.Update(newsDAL);
            Database.Save();
        }

        public IEnumerable<SectionDTO> GetAllSections()
        {
            var allSections = Database.News.GetAllSections().ToList();
            var sectionDTO= Mapper.Map<IEnumerable<SectionDTO>>(allSections).ToList();
            return sectionDTO;
        }
    }
}
