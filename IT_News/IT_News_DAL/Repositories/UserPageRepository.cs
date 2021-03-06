﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IT_News_DAL.EF;
using IT_News_DAL.Entities;
using IT_News_DAL.Interfaces;

namespace IT_News_DAL.Repositories
{
    public class UserPageRepository : IRepository<UserPage>
    {
        private readonly NewsContext _db;

        public UserPageRepository(NewsContext context)
        {
            _db = context;
        }
        public void Create(UserPage page)
        {
            _db.UserPage.Add(page);
            _db.Entry(page).State = EntityState.Added;
        }

        public UserPage Get(int idUser)
        {
            return _db.UserPage.Find(idUser);
        }
        public UserPage Get(string idUser)
        {
            return _db.UserPage.ToList().Find(page => page.UserId == idUser);
        }
        public IEnumerable<UserPage> GetAll()
        {
            return _db.UserPage.ToList();
        }       

        #region MyRegion    
        public void Create(UserPage item, List<Tag> element)
        {
            throw new NotImplementedException();
        }
        public void Create(UserPage page, List<News> listNews)
        {
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Section> GetAllSections()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetAllTags()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserPage> GetAllUsers()
        {
            throw new NotImplementedException();
        }
        public void Update(UserPage item, List<Tag>tags)
        {
            throw new NotImplementedException();
        }
        public void Create(Comment item)
        {

        }
        public void Save(News news, decimal total)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
