using _24HourBuild.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourBuild.Models.Comment
{
    public class CommentCreate
    {
        public int CommentID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
    
        public string CommentText { get; set; }

        [Required]
        [MaxLength(10000)]
        public User CommentAuthor { get; set; }

        

        public string PostText { get; set; }
        public string PostTitle { get; set; }
        public User Author { get; set; }

        


    }
}
