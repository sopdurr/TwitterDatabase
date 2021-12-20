using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace twitterAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string UserName { get; set; }

        public List<Tweet> Tweets { get; set; } = new List<Tweet>();

    }
}
