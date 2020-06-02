using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Data
{
    public class Reply : Comment
    {
        
        //[Key]
        //public int CommentID { get; set; }
        //public string CommentText { get; set; }

        //[ForeignKey("CommentAuthor")]
        //public int UserID { get; set; }
        //public virtual User CommentAuthor { get; set; }

        //[ForeignKey("Post")]
        //public int PostID { get; set; }
        //public virtual Post Post { get; set; }
        public virtual Comment Comment { get; set; }


    }
}
