using System;
namespace twitterAPI.Models
{
    public class Like
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int TweetId { get; set; }
    }
}
