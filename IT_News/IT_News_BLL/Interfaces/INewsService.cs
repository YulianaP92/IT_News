using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_News_BLL.DTO;

namespace IT_News_BLL.Interfaces
{
    public interface INewsService
    {
        IEnumerable<NewsDTO> GetAll();
        NewsDTO Get(int id);
        void Create(NewsDTO item);
        void Update(NewsDTO item);
        void Delete(int id);
    }
}
