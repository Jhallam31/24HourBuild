﻿using _24HourBuild.Data;
using _24HourBuild.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Services
{
    public class CommentService
    {
        private readonly int _userID;

        public CommentService(int userId)
        {
            _userID = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {

                    CommentID = model.CommentID,
                    CommentText = model.CommentText,
                    PostText = model.PostText,
                    CommentAuthor = model.CommentAuthor
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentID = e.CommentID,
                                    PostTitle = e.PostTitle,
                                    CommentText = e.CommentText,
                                    CommentAuthor = e.CommentAuthor,
                                    PostText= e.PostText,

                                }
                        );

                return query.ToArray();
            }
        }
        public CommentDetail GetCommentByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentID == id && e.UserID == _userID);
                return
                    new CommentDetail
                    {
                        CommentID = entity.CommentID,
                        CommentText= entity.CommentText,
                        CommentAuthor= entity.CommentAuthor,
                        PostTitle = entity.PostTitle,
                        PostText = entity.PostText,

                    };
            }
        }
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentID == model.CommentID && e.UserID == _userID);
                entity.CommentID = model.CommentID;
                entity.CommentText = model.CommentText;
                

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentID == commentID && e.UserID == _userID);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
