namespace IT_News.Models.News
{
    public class TagCloud : TagViewModel
    {
        public int CountOfTag { get; set; } //кол-во тегов
        public int TotalNews { get; set; } //кол-во новостей
    }
}