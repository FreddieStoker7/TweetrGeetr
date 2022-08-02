using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetrGeetr.Models
{
    public class Tweet
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public SocialMediaType SocialMediaType { get; set; } 
        [JsonProperty("text")]
        public string TweetContent { get; set; }
    }



}
