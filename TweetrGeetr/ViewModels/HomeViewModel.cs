using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetrGeetr.Models;
using static TweetrGeetr.Models.DataFixer;

namespace TweetrGeetr.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Datum> Tweets { get; set; }
        public List<BlogComment> MatchingComments { get; set; }
    }
}
