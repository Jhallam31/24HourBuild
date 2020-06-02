using _24HourBuild.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Models.Reply
{
    public class ReplyDetail 
    {
        public int CommentID { get; set; }
        public string CommentText { get; set; }

        public User CommentAuthor { get; set; }

        public string PostText { get; set; }

        public string ReplyComment { get; set; }


    }
}
