using System.Collections.Generic;
using IT_News_BLL.DTO;

namespace IT_News_BLL.Interfaces
{
    //!!!!!!!!!!!!!!Разделить интерфейс
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Get(string id);
        void Create(T item);
        void Create(T item, List<TagDTO> element);
        void Create(T item, List<NewsDTO> element);
        void Create(CommentDTO item);
        void Update(T item, List<TagDTO> element);
        void Delete(int id);
        IEnumerable<SectionDTO> GetAllSections();
        IEnumerable<TagDTO> GetAllTags();
        IEnumerable<UserPageDTO> GetAllUsers();
    }
}
