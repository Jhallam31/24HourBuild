using _24HourBuild.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Models.Like
{
    public class LikeDetail
    {
        [Key]
        public int LikeID { get; set; }
        public string UserName { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        public bool IsLiked { get; set; }
    }
}
