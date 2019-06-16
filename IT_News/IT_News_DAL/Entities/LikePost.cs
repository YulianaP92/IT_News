namespace IT_News_DAL.Entities
{
    public class LikePost
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int CommentId { get; set; }
        public string User { get; set; }
        public bool Like { get; set; }
    }
}
