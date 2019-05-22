using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Create(UserPage item)
        {
            throw new NotImplementedException();
        }

        public void Create(UserPage item, List<Tag> element)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserPage Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserPage> GetAll()
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

        public void Update(UserPage item)
        {
            throw new NotImplementedException();
        }
    }
}
