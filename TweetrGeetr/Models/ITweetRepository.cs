using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TweetrGeetr.Models.DataFixer;

namespace TweetrGeetr.Models
{
    public interface ITweetRepository
    {
        
        IEnumerable<Datum> AllTweets { get; }
        Datum GetTweetById(string TweetId);

        

    }
}
