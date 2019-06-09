using System.Collections.Generic;

namespace IT_News_DAL.Entities
{
    public class UserPage
    {
        public int Id { get; set; }
        public string  UserId{ get; set; }
        public virtual List<News> News { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
