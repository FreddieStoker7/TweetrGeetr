using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        

        //public ViewResult List()
        //{
        //    TweetListViewModel tweetListViewModel = new TweetListViewModel();
        //    tweetListViewModel.AllTweets = _tweetRepository.AllTweets;

        //    tweetListViewModel.LatestBlogEntries = "Latest Blog Entries";
        //    return View(tweetListViewModel);
        //}
        [HttpGet]
        public async Task<IActionResult> Search(string searchQuery)
        {
            
            var url = "https://api.twitter.com/2/tweets/search/recent?query=" + searchQuery;
            var bearerAccessToken = "AAAAAAAAAAAAAAAAAAAAAMBHfQEAAAAA2cixCv%2BDTgF6qzQKdHW8LLtidY8%3DVbflRa4zCO3gQOpsxKK2WIuwZ08tRc1KkFgYLWFCkbn9Y7Y2ez";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerAccessToken}");

            var response = await httpClient.GetAsync(url);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            

            var parsedObject = JObject.Parse(jsonResponse);
            var justDataJson = parsedObject["data"].ToString();
            
            var returnedTweets = JsonConvert.DeserializeObject<DataFixer.Root>(jsonResponse);
            var returnedArray = returnedTweets.data;
            List<Datum> TweetList = new List<Datum>();
            foreach (DataFixer.Datum tweet in returnedArray)
            {
                TweetList.Add(tweet);
                

                
            }

            _tweetRepository.AddTweetsToDb(TweetList);
            _tweetRepository._appDbContext.SaveChanges();


            return View(TweetList);
        }

        public IActionResult BlogThis(string id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            if (tweet == null)
                return NotFound();

            return View(tweet);
        }

        public IActionResult Success(string id, string addedComment)
        {
            var newComment = new BlogComment()
            {
                id = id,
                CommentContent = addedComment,
                DateTimePosted = DateTime.Now
            };


            _commentRepository.AddCommentsToDb(newComment);
            _commentRepository._appDbContext.SaveChanges();
            var tweetToChangeStatus = _tweetRepository.GetTweetById(id);
            tweetToChangeStatus.isItBlogged = true;
            //_tweetRepository.AttachCommentsToTweet(newComment, id);
            _tweetRepository._appDbContext.SaveChanges();

            var tweetToPass = _tweetRepository.GetTweetById(id);
            ViewBag.tweet = tweetToPass;
            return View(newComment);
        }
        
    }
}
