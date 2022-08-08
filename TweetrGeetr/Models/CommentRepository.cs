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
        public List<BlogComment> GetCommentsByTweetId(string tweetId)
        {
            List<BlogComment> returnedComments = new List<BlogComment>();

            foreach (BlogComment comment in BlogComments)
            {
                if (comment.id == tweetId)
                {
                    returnedComments.Add(comment);
                }
            }
            return returnedComments;
        }

        public void AddCommentsToDb(BlogComment comment)
        {
            _appDbContext.Add(comment);
        }
    }
}
