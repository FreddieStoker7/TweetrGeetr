using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TweetrGeetr.Models;
using TweetrGeetr.ViewModels;

namespace TweetrGeetr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITweetRepository _tweetRepository;

        public HomeController(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            return View(homeViewModel);
        }

        
    }
}
