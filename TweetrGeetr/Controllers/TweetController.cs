using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TweetrGeetr.Models;
using TweetrGeetr.ViewModels;
using static TweetrGeetr.Models.DataFixer;

namespace TweetrGeetr.Controllers
{
    public class TweetController : Controller
    {
        

   

        public  TweetRepository _tweetRepository;

        public CommentRepository _commentRepository;

        public TweetController(TweetRepository tweetRepository, CommentRepository commentRepository)
        {
            _tweetRepository = tweetRepository;
            _commentRepository = commentRepository;
        }
        

        
        [HttpGet]
        public async Task<IActionResult> Search(string searchQuery)
        {
            Char[] buffer;
            var badWordsList = new List<string>();
            using (var sr = new StreamReader("BadWords.txt"))
            {
                buffer = new Char[(int)sr.BaseStream.Length];
                await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
            }
            var consolelog = new String(buffer);
            var splitWords = consolelog.Split("\r\n");

            badWordsList.AddRange(splitWords);

            if (badWordsList.Contains(searchQuery))
            {
                return View("~/Views/Shared/SearchExplicit.cshtml");
            }


            var url = "https://api.twitter.com/2/tweets/search/recent?query=" + searchQuery;
            var bearerAccessToken = "AAAAAAAAAAAAAAAAAAAAAMBHfQEAAAAA2cixCv%2BDTgF6qzQKdHW8LLtidY8%3DVbflRa4zCO3gQOpsxKK2WIuwZ08tRc1KkFgYLWFCkbn9Y7Y2ez";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerAccessToken}");

            var response = await httpClient.GetAsync(url);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            var returnedTweets = JsonConvert.DeserializeObject<DataFixer.Root>(jsonResponse);
            var returnedArray = returnedTweets.data ?? new List<Datum>();
            List<Datum> TweetList = new List<Datum>();
            foreach (DataFixer.Datum tweet in returnedArray)
            {
                TweetList.Add(tweet);
        
            }
            
            _tweetRepository.AddTweetsToDb(TweetList);
            _tweetRepository._appDbContext.SaveChanges();

            ViewBag.SearchQuery = searchQuery;

            return View(TweetList);
        }

        public IActionResult BlogThis(string id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            if (tweet == null)
                return NotFound();

            return View(tweet);
        }

        public async Task<IActionResult> Success(string id, string addedComment)
        {

            Char[] buffer;
            var badWordsList = new List<string>();
            using (var sr = new StreamReader("BadWords.txt"))
            {
                buffer = new Char[(int)sr.BaseStream.Length];
                await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
            }
            var consolelog = new String(buffer);
            var splitWords = consolelog.Split("\r\n");

            badWordsList.AddRange(splitWords);

            var splitCommentList = new List<string>();
            var splitCommentArray = addedComment.Split(" ");
            splitCommentList.AddRange(splitCommentArray);
            string expletiveFreeComment = "";

            foreach(string word in splitCommentList)
            {
                if (badWordsList.Contains(word))
                {

                    expletiveFreeComment += " ****";
                }
                else
                {
                    expletiveFreeComment += " " + word;
                }
            }

            var newComment = new BlogComment()
            {
                id = id,
                CommentContent = expletiveFreeComment,
                DateTimePosted = DateTime.Now
            };


            _commentRepository.AddCommentsToDb(newComment);
            _commentRepository._appDbContext.SaveChanges();
            var tweetToChangeStatus = _tweetRepository.GetTweetById(id);
            tweetToChangeStatus.isItBlogged = true;
            _tweetRepository._appDbContext.SaveChanges();

            var tweetToPass = _tweetRepository.GetTweetById(id);
            ViewBag.tweet = tweetToPass;
            return View(newComment);
        }
        
    }
}
