using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TweetrGeetr.Models.DataFixer;

namespace TweetrGeetr.Models
{
    public interface ITweetRepository
    {
        List<Datum> AllTweetsFromApi { get; set; }
        IEnumerable<Tweet> AllTweets { get; }
        Tweet GetTweetById(int TweetId);
    }
}
