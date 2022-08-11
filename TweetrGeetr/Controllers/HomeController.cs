using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TweetrGeetr.Models;
using TweetrGeetr.ViewModels;
using static TweetrGeetr.Models.DataFixer;

namespace TweetrGeetr.Controllers
{
    public class HomeController : Controller
    {
        public TweetRepository _tweetRepository;
        public CommentRepository _commentRepository;

        public HomeController(TweetRepository tweetRepository, CommentRepository commentRepository)
        {
            _tweetRepository = tweetRepository;
            _commentRepository = commentRepository;
        }

        public IActionResult Index()
        {
            var bloggedTweets = _tweetRepository.AllTweets.Where(tweet => tweet.isItBlogged == true);
            List<BlogComment> BloggedTweetsComments = new List<BlogComment>();

            foreach (Datum tweet in bloggedTweets)
            {
                var commentsToAdd = _commentRepository.GetCommentsByTweetId(tweet.id);
                BloggedTweetsComments.AddRange(commentsToAdd);
                
            };



            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.MatchingComments = BloggedTweetsComments;
            homeViewModel.Tweets = bloggedTweets;

            return View(homeViewModel);
        }

        public IActionResult Blogs()
        {
            var bloggedTweets = _tweetRepository.AllTweets.Where(tweet => tweet.isItBlogged == true);
            List<BlogComment> BloggedTweetsComments = new List<BlogComment>();

            foreach (Datum tweet in bloggedTweets)
            {
                var commentsToAdd = _commentRepository.GetCommentsByTweetId(tweet.id);
                BloggedTweetsComments.AddRange(commentsToAdd);

            };



            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.MatchingComments = BloggedTweetsComments;
            homeViewModel.Tweets = bloggedTweets;

            return View(homeViewModel);
        }


    }
}
