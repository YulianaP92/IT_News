namespace IT_News_BLL.DTO
{
    public  class LikePostDto
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int CommentId { get; set; }
        public string User { get; set; }
        public bool Like { get; set; }
    }
}
