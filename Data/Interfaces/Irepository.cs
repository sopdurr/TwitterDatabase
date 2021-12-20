using System;
using System.Collections.Generic;
using twitterAPI.Models;

namespace twitterAPI.Data
{
    public interface Irepository
    {
        List<Tweet> GetAllTweets();

        Tweet GetTweetById(int id);

        List<User> GetUser();

        User GetUserById(int id);

        void AddTweet(Tweet tweet);

        void AddUser(User user);

        Tweet UpdateTweet(int id, Tweet tweet);

        User UpdateUser(int id, User user);
    }
}
