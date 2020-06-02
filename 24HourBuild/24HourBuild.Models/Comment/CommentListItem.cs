using _24HourBuild.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Models.Comment
{
    public class CommentListItem
    {
        public int CommentID { get; set; }

        [Display(Name = "Comment")]
        public string CommentText { get; set; }

        [Display(Name = "Author")]
        public User CommentAuthor { get; set; }

        
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        public User Author { get; set; }
    }
}
