using _24HourBuild.Data;
using _24HourBuild.Models.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Services
{
    public class ReplyService
    {
        private readonly int _userID;

        public ReplyService(int userId)
        {
            _userID = userId;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {

                    CommentID = model.CommentID,
                    CommentText = model.CommentText,
                    ReplyComment= model.ReplyComment,
                    CommentAuthor = model.CommentAuthor
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    CommentID = e.CommentID,
                                    ReplyComment= e.ReplyComment,
                                    CommentText = e.CommentText,
                                    CommentAuthor = e.CommentAuthor,
                                    PostTitle = e.PostTitle,
                                    PostText = e.PostText,

                                }
                        );

                return query.ToArray();
            }
        }
        public ReplyDetail GetReplyByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.CommentID == id && e.UserID == _userID);
                return
                    new ReplyDetail
                    {
                        CommentID = entity.CommentID,
                        CommentText = entity.CommentText,
                        CommentAuthor = entity.CommentAuthor,
                        ReplyComment = entity.ReplyComment,
                        PostText = entity.PostText,

                    };
            }
        }
        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.CommentID == model.CommentID && e.UserID == _userID);
                entity.CommentID = model.CommentID;
                entity.CommentText = model.CommentText;
                entity.ReplyComment = model.ReplyComment;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReply(int replyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.CommentID == replyID && e.UserID == _userID);

                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
