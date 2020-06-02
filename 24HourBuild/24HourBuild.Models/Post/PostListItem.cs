using _24HourBuild.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Models.Post
{
    public class PostListItem
    {
        public int PostID { get; set; }


        public string PostTitle { get; set; }


        public string PostText { get; set; }


        public virtual User Author { get; set; }
        public int UserID { get; set; }
    }
}
