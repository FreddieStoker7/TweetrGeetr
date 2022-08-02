using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetrGeetr.Models
{
    public class BlogComment
    {
        public int Id { get; set; }
        public int BlogEntryId { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateTimePosted { get; set; }

    }
}
