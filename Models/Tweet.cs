using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace twitterAPI.Models
{
    public class Tweet
    {
        
        public int Id { get; set; }

        public int Likes { get; set; }

        [Required]
        [MaxLength(280)]
        public string Content { get; set; }

        [Required]
        public string User { get; set; }

    }
}
