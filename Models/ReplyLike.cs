using System;
namespace twitterAPI.Models
{
    public class ReplyLike
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ReplyId { get; set; }
    }
}
