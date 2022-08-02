using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TweetrGeetr.Models.DataFixer;

namespace TweetrGeetr.Models
{
    public class TweetRepository : ITweetRepository
    {
        private readonly AppDbContext _appDbContext;

        public TweetRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            AllTweetsFromApi = new List<Datum>();
        }

        public IEnumerable<Tweet> AllTweets
        {
            get
            {
                return _appDbContext.Tweets; 
            }
        }
        public List<Datum> AllTweetsFromApi { get; set; } 

        public Tweet GetTweetById(int TweetId)
        {
            return _appDbContext.Tweets.FirstOrDefault(t => t.Id == TweetId);
        }
    }
}
