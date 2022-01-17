using System;
using Microsoft.EntityFrameworkCore;
using twitterAPI.Models;

namespace twitterAPI.Data
{
    public class TwitterDbContext: DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<ReplyLike> ReplyLikes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cn = @"filename=/Users/sopur/Desktop/Twitter.Db";
            optionsBuilder.UseSqlite(cn);
            base.OnConfiguring(optionsBuilder);
        }

        
    }
}
