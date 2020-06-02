using _24HourBuild.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Models.Comment
{
    public class CommentDetail
    {
        public int CommentID { get; set; }

        public string CommentText { get; set; }
       
        public User CommentAuthor { get; set; }

        


        public string PostTitle { get; set; }
        public string PostText { get; set; }
        public User Author { get; set; }
    }
}
