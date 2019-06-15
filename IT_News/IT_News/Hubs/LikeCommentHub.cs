using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IT_News_BLL.DTO;
using IT_News_BLL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using AutoMapper;
using IT_News.Models;
using IT_News_DAL.EF;
using IT_News_DAL.Entities;


namespace IT_News.Hubs
{
    [HubName("likeCommentHub")]
    public class LikeCommentHub : Hub
    {
        //private IService<NewsDTO> newsService;
        private readonly NewsContext _db;
        public LikeCommentHub()
        {
            this._db = DependencyResolver.Current.GetService<NewsContext>();

        }

        public Task Like(int newstId, int commentId)
        {
            var likePost = SaveLike(newstId,commentId);
            return Clients.All.updateLikeCount(likePost);
        }
        private int SaveLike(int newstId, int commentId)
        {
            var news = _db.News.Where(x => x.Id == newstId).FirstOrDefault();
            var comment = news.Comments.Where(x => x.CommentId == commentId).FirstOrDefault();
            LikePost liked = null;
            if (comment!=null)
            {
                liked = new LikePost()
                {
                    CommentId = comment.CommentId,
                    NewsId = news.Id,
                    Like = true,
                    User = HttpContext.Current.User.Identity.GetUserId()

                };
            }

            var like = comment.PostLikes.FirstOrDefault(e => e.User == liked.User);
            if (like == null)
            {
                
                comment.PostLikes.Add(liked);
               
            }
            else
            {
                like.Like = !like.Like;
            }
            comment.LikeCount= comment.PostLikes.Count(e => e.Like);
            var i = comment.LikeCount;
            _db.SaveChanges();
            
            return  comment.PostLikes.Count(e => e.Like);

        }

    }
}