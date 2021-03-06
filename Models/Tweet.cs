using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace twitterAPI.Models
{
    public class Tweet
    {
        
        public int Id { get; set; }

        public List<Like> Likes { get; set; }

        [Required]
        [MaxLength(280)]
        public string Content { get; set; }

        public List<Reply> Replies { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }


    }
}

