using _24HourBuild.Data;
using _24HourBuild.Models.Like;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Services
{
    public class LikeService
    {
        private readonly int _userID;

        public LikeService(int userId)
        {
            _userID = userId;
        }
        public bool CreateLike(LikeCreate model)
        {
            var entity =
                new Like()
                {

                    PostTitle = model.PostTitle,
                    PostText = model.PostText,
                    IsLiked = model.IsLiked,
                    UserID = model.UserID,
                    UserName =model.UserName
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LikeListItem> GetLikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Likes
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new LikeListItem
                                {
                                    PostText = e.PostText,
                                    PostTitle = e.PostTitle,
                                    UserName = e.UserName,
                                    IsLiked = e.IsLiked,
                                    UserID = e.UserID
                                }
                        );

                return query.ToArray();
            }
        }
        public LikeDetail GetLikeByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Likes
                    .Single(e => e.LikeID == id && e.UserID == _userID);
                return
                    new LikeDetail
                    {
                        LikeID = entity.LikeID,
                        PostText = entity.PostText,
                        PostTitle = entity.PostTitle,
                        IsLiked = entity.IsLiked,
                        UserName = entity.UserName
                        

                    };
            }
        }
        public bool UpdateLike(LikeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Likes
                    .Single(e => e.LikeID == model.LikeID && e.UserID == _userID);
                entity.LikeID = model.LikeID;
                entity.IsLiked = model.IsLiked;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLike(int likeID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Likes
                    .Single(e => e.LikeID == likeID && e.UserID == _userID);

                ctx.Likes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
