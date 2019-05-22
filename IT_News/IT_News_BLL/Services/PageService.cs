using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;

namespace IT_News_BLL.Services
{
    public class PageService : IService<UserPageDTO>
    {
        public void Create(UserPageDTO item)
        {
            throw new NotImplementedException();
        }

        public void Create(UserPageDTO item, List<TagDTO> tags)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserPageDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserPageDTO> GetAll()
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

        public void Update(UserPageDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
