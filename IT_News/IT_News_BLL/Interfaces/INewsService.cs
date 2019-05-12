using System.Collections.Generic;
using IT_News_BLL.DTO;

namespace IT_News_BLL.Interfaces
{
    public interface INewsService
    {
        IEnumerable<NewsDTO> GetAll();
        NewsDTO Get(int id);
        void Create(NewsDTO item, List<TagDTO> tags);
        void Update(NewsDTO item);
        void Delete(int id);
        IEnumerable<SectionDTO> GetAllSections();
        IEnumerable<TagDTO> GetAllTags();
    }
}
