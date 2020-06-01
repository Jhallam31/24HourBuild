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
        [Required]
        [ForeignKey("Post")]
        public Guid PostID { get; set; }
        public virtual Post Post { get; set; }

       public User User { get; set; }


    }
}
