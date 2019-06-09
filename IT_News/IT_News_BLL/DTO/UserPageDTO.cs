using System.Collections.Generic;

namespace IT_News_BLL.DTO
{
    public class UserPageDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual List<NewsDTO> News { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
