using _24HourBuild.Data;
using _24HourBuild.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Services
{
    public class PostService
    {
        private readonly int _userID;

        public PostService(int userId)
        {
            _userID = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    
                    PostID = model.PostID,
                    PostTitle = model.PostTitle,
                    PostText = model.PostText,
                    Author = model.Author
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    PostID = e.PostID,
                                    PostTitle = e.PostTitle,
                                    PostText = e.PostText,
                                    Author = e.Author,
                                    UserID = e.UserID
                                    
                                }
                        );

                return query.ToArray();
            }
        }
        public PostDetail GetPostByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.PostID == id && e.UserID == _userID);
                return
                    new PostDetail
                    {
                        PostID = entity.PostID,
                        PostTitle = entity.PostTitle,
                        PostText = entity.PostText,
                        Author = entity.Author
                        
                    };
            }
        }
        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.PostID == model.PostID && e.UserID == _userID);
                entity.PostTitle = model.PostTitle;
                entity.PostText = model.PostText;
                entity.Author = entity.Author;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePost(int postID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.PostID == postID && e.UserID == _userID);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
