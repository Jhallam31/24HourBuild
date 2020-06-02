using _24HourBuild.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Models.Reply
{
    public class ReplyListItem
    {
        public int ReplyID { get; set; }
        public int CommentID { get; set; }

        [Display(Name = "Comment")]
        public string CommentText { get; set; }

        [Display(Name = "Author")]
        public User CommentAuthor { get; set; }

        public string PostTitle { get; set; }
        public string PostText { get; set; }

        public string UserName { get; set; }
    }
}
