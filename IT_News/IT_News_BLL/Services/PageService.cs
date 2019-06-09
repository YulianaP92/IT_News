using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using IT_News_DAL.Entities;
using IT_News_DAL.Interfaces;

namespace IT_News_BLL.Services
{
    public class PageService : IService<UserPageDTO>
    {
        IUnitOfWork Database { get; set; }

        public PageService(IUnitOfWork database)
        {
            this.Database = database;
        }
        public void Create(UserPageDTO pageDto)
        {

            var pageDal = Mapper.Map<UserPage>(pageDto);
            Database.UserPage.Create(pageDal);
            Database.Save();
        }

        public UserPageDTO Get(int id)
        {
            var page = Database.UserPage.Get(id);
            var result = Mapper.Map<UserPageDTO>(page);
            return result;
        }

        public IEnumerable<UserPageDTO> GetAll()
        {
            var allPage = Database.UserPage.GetAll().ToList();
            var result = Mapper.Map<IEnumerable<UserPageDTO>>(allPage);
            return result;
        }
        public UserPageDTO Get(string id)
        {
            var userPage = Database.UserPage.Get(id);
            var result = Mapper.Map<UserPageDTO>(userPage);
            return result;          
        }

       

        #region MyRegion

        public void Create(UserPageDTO item, List<TagDTO> tags)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<SectionDTO> GetAllSections()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TagDTO> GetAllTags()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserPageDTO> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public void Update(UserPageDTO item,List<TagDTO>tags)
        {
            throw new NotImplementedException();
        }
        public void Create(UserPageDTO item, List<NewsDTO> news)
        {
            throw new NotImplementedException();
        }
        public void Create(CommentDTO item)
        {
            throw new NotImplementedException();
        }

        public void Save(NewsDTO news, decimal total)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
