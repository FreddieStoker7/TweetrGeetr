using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetrGeetr.Models
{
    public class CommentRepository
    {
        public AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public IEnumerable<BlogComment> BlogComments
        {
            get
            {
                return _appDbContext.BlogComments;
            }
        }
        public BlogComment GetCommentsByTweetId(string tweetId)
        {
            return (BlogComment)BlogComments.Where(t => t.id == tweetId);
        }

        public void AddCommentsToDb(BlogComment comment)
        {
            _appDbContext.Add(comment);
        }
    }
}
