using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetrGeetr.Models
{
    public class DataFixer
    {
        public class Datum
        {
            public string id { get; set; }
            public string text { get; set; }
            public bool isItBlogged { get; set; } = false;
        }

        public class Meta
        {
            public string newest_id { get; set; }
            public string oldest_id { get; set; }
            public int result_count { get; set; }
            public string next_token { get; set; }
        }

        public class Root
        {
            public List<Datum> data { get; set; }
            public Meta meta { get; set; }
        }
    }
}
