using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TweetrGeetr.Models.DataFixer;

namespace TweetrGeetr.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Datum> AllTweets { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<SocialMediaType> SocialMediaTypes { get; set; }


    }
}
