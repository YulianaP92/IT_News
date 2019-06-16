using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using IT_News_DAL.Entities;
using IT_News_DAL.Interfaces;

namespace IT_News_BLL.Services
{
    public class NewsService : IService<NewsDTO>
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
        //исправить реализацию метода Update
        public void Update(NewsDTO newPost,List<TagDTO> tags)
        {
            var tagCollection = Mapper.Map<List<Tag>>(tags);
            //var oldPost = Database.News.Get(newPost.Id);
            //oldPost = Mapper.Map(newPost, oldPost);
            //Database.News.Update(oldPost);
            var newsDal = Mapper.Map<News>(newPost);
            Database.News.Update(newsDal, tagCollection);
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
        
        public IEnumerable<UserPageDTO> GetAllUsers()
        {
            var allUsers = Database.News.GetAllUsers().ToList();
            var allUsersDto = Mapper.Map<IEnumerable<UserPageDTO>>(allUsers).ToList();
            return allUsersDto;
        }

        public void Create(CommentDTO item)
        {
            var commentDAL = Mapper.Map<Comment>(item);
            commentDAL.News = Database.News.Get(item.NewsId);
            Database.News.Create(commentDAL);
            Database.Save();
        }
        public void Save(NewsDTO newsDto, decimal total)
        {          
            var news=Mapper.Map<News>(newsDto);
            Database.News.Save(news, total);
        }
        #region MyRegion
        public void Create(NewsDTO item)
        {
            throw new System.NotImplementedException();
        }

        public NewsDTO Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(NewsDTO item, List<NewsDTO> element)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
