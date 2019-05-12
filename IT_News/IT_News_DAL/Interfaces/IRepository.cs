using System.Collections.Generic;
using IT_News_DAL.Entities;

namespace IT_News_DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item, List<Tag> tags);
        void Update(T item);
        void Delete(int id);
        IEnumerable<Section> GetAllSections();
        IEnumerable<Tag> GetAllTags();
        //IEnumerable<TagClouds> GetTagClouds();
    }
}
