using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Data
{
    public class Post
    {
        [Key]   
        public Guid PostID { get; set; }
        
        [Required]
        public string PostTitle { get; set; }

        [Required]
        public string PostText { get; set; }




       
       
        [ForeignKey("Author")]
        public Guid UserID { get; set; }
        public virtual User Author { get; set; }

    }
}
