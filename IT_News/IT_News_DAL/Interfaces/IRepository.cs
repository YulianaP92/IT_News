using System.Collections.Generic;
using IT_News_DAL.Entities;

namespace IT_News_DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<UserPage> GetAllUsers();
        T Get(int id);
        T Get(string id);
        void Create(T item, List<Tag> element);
        void Create(T item, List<News> element);
        void Create(T item);
        void Create(Comment item);
        void Update(T item);
        void Delete(int id);
        IEnumerable<Section> GetAllSections();
        IEnumerable<Tag> GetAllTags();
    }
}
