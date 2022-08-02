using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetrGeetr.Models;

namespace TweetrGeetr.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Tweet> Tweets { get; set; }
    }
}
