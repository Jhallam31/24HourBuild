using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Data
{
    public class Reply : Comment
    {
        
        
        [ForeignKey("Comment")]
        public Guid ReplyCommentID { get; set; }
        public virtual Comment ParentComment { get; set; }
        

    }
}
