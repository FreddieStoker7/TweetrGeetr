using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetrGeetr.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<SocialMediaType> SocialMediaTypes { get; set; }

    }
}
