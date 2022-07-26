﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TweetrGeetr.Models.DataFixer;

namespace TweetrGeetr.Models
{
    public class TweetRepository : ITweetRepository
    {
        public AppDbContext _appDbContext;

        public TweetRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public IEnumerable<Datum> AllTweets
        {
            get
            {
                return _appDbContext.AllTweets;
            }
        }

        public Datum GetTweetById(string TweetId)
        {
            return AllTweets.FirstOrDefault(t => t.id == TweetId);
        }

        public void AddTweetsToDb(List<Datum> tweetList)
        {
            _appDbContext.AddRange(tweetList);
        }

    }
}
