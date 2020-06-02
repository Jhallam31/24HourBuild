using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Data
{
    public class Like
    {
        public int LikeID { get; set; }

        public bool IsLiked { get; set; }

        [Required]
        [ForeignKey("ParentPost")]
        public int PostID { get; set; }
        public virtual Post ParentPost { get; set; }

        public string PostTitle { get; set; }
        public string PostText { get; set; }

        public int UserID { get; set; }
        public string UserName { get; set; }
        


    }
}
