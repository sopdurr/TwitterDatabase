using System;
using Microsoft.EntityFrameworkCore;
using twitterAPI.Models;

namespace twitterAPI.Data
{
    public class TwitterDbContext: DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

         optionsBuilder.UseSqlite(@"filename=/Users/sopur/Desktop/Twitter.Db");

        }

        
    }
}
