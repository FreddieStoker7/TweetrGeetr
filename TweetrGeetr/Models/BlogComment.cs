using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TweetrGeetr.Models
{
    public class BlogComment
    {
        public string id { get; set; }
        [Key]
        public int BlogEntryId { get; set; }
        
        [StringLength(300, MinimumLength = 1)]
        [Required]
        public string CommentContent { get; set; }
        public DateTime DateTimePosted { get; set; }

    }
}
