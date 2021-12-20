using System;
using System.Collections.Generic;
using System.Linq;
using twitterAPI.Models;

namespace twitterAPI.Data
{
    public class MockRepo : Irepository
    {

        List<Tweet> Tweets = new List<Tweet>()
         {
                new Tweet() { Id = 1, Content = "HALLO EG ÞARF AÐ DREKKA", Likes = 2, User = "MockSiggiJons"},
                new Tweet() { Id = 2, Content = "HALLO EG ÞARF AÐ FARA I RÆKTINA", Likes = 1, User = "MockSiggiJons"},
                new Tweet() { Id = 3, Content = "HALLO EG ÞARF AÐ BOMBA", Likes = 4, User = "MockSiggiJons"}
         };

        List<User> User = new List<User>()
        {
            new User() { Id=1, UserName="Siggi" },
        };

        public void AddTweet(Tweet tweet)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<Tweet> GetAllTweets()
        {
            return Tweets;
        }

        

        public Tweet GetTweetById(int id)
        { 
            return Tweets.FirstOrDefault(x => x.Id == id);
        }


        public List<User> GetUser()
        {
            return User;
        }

        public User GetUserById(int id)
        {
            return User.FirstOrDefault(x => x.Id == id);
        }

        public Tweet UpdateTweet(int id, Tweet tweet)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }

}
