using System.Collections.Generic;
using IT_News_BLL.DTO;

namespace IT_News_BLL.Interfaces
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Get(string id);
        void Create(T item);
        void Create(T item, List<TagDTO> element);
        void Create(T item, List<NewsDTO> element);
        void Update(T item);
        void Delete(int id);
        IEnumerable<SectionDTO> GetAllSections();
        IEnumerable<TagDTO> GetAllTags();
        IEnumerable<UserPageDTO> GetAllUsers();
    }
}
