using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetrGeetr.Models;
using static TweetrGeetr.Models.DataFixer;

namespace TweetrGeetr.ViewModels
{
    public class TweetListViewModel
    {
        public DataFixer dataFixer { get; set; }
        public List<Datum> AllTweetsFromApi { get; set; }
        public string LatestBlogEntries { get; internal set; }
    }
}
