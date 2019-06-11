using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace IT_News.Hubs
{
    [HubName("likeCommentHub")]
    public class LikeCommentHub : Hub
    {
        private IService<NewsDTO> newsService;

        public LikeCommentHub()
        {
            this.newsService = DependencyResolver.Current.GetService<IService<NewsDTO>>();
        }
        public Task Like(int newstId, int commentId)
        {
            var likePost = SaveLike(newstId,commentId);
            return Clients.All.updateLikeCount(likePost);
        }
        private int SaveLike(int newstId, int commentId)
        {
            var baseContext = this.Context.Request.GetHttpContext();
            var newsDto = newsService.Get(newstId);
            var commentDto = newsDto.Comments.Where(x => x.CommentId == commentId).FirstOrDefault();
            var liked = new LikePostDto
            {
                CommentId = commentDto.CommentId,
                NewsId = newsDto.Id,
                Like = true,
                UserId = baseContext.Request.UserHostAddress
            };
            var like = commentDto.PostLikes.FirstOrDefault(e => e.UserId == liked.UserId);
            if (like == null)
            {
                commentDto.PostLikes.Add(liked);
            }
            else
            {
                like.Like = !like.Like;
            }

            return  commentDto.PostLikes.Count(e => e.Like);

        }

    }
}