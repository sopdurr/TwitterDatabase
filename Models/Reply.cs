using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace twitterAPI.Models
{
    public class Reply
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(280)]
        public string ReplyContent { get; set; }

        public List <ReplyLike> ReplyLikes { get; set; }

        public DateTime ReplyDate { get; set; }

        public int UserId { get; set; }

        public int TweetId { get; set; }

    }
}
