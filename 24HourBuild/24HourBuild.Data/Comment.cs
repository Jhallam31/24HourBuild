using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Data
{
    public class Comment
    {
        [ForeignKey("Post")]
        public Guid PostID { get; set; }
        public virtual Post Post { get; set; }

        [Key]
        public Guid CommentID { get; set; }
        public string CommentText { get; set; }

        [ForeignKey("CommentAuthor")]
        public Guid UserID { get; set; }
        public virtual User CommentAuthor { get; set; }

    }
}
